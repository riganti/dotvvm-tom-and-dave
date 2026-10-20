export default (context: DotvvmModuleContext) => new PasskeysModule(context);

class PasskeysModule {
    private busy = false;

    public constructor(private readonly context: DotvvmModuleContext) {
    }

    public async passkeyRegister(deviceName: string): Promise<void> {
        await this.run(async () => {
            if (!deviceName?.trim() || deviceName.length > 100) {
                throw new Error("Device name is required and must not exceed 100 characters.");
            }

            const optionsJson = await this.context.namedCommands.GetRegistrationOptions();
            const publicKey = PublicKeyCredential.parseCreationOptionsFromJSON(JSON.parse(optionsJson));
            const credential = await navigator.credentials.create({ publicKey }).catch((error: unknown) => {
                if (error instanceof DOMException && error.name === "NotAllowedError") {
                    throw new Error("Passkey registration was canceled.");
                }

                throw error;
            });

            if (!credential) {
                throw new Error("No credential was returned.");
            }

            const result = await this.context.namedCommands.CompleteRegistration(JSON.stringify(credential), deviceName);
            if (!result.Succeeded) {
                throw new Error(result.Error);
            }

            this.setStatus("Passkey saved! Taking you back…", "success");
            window.location.assign("/profile/security");
        });
    }

    public async passkeyLogin(): Promise<void> {
        await this.run(async () => {
            const optionsJson = await this.context.namedCommands.GetLoginOptions();
            const publicKey = PublicKeyCredential.parseRequestOptionsFromJSON(JSON.parse(optionsJson));
            const credential = await navigator.credentials.get({ publicKey }).catch((error: unknown) => {
                if (error instanceof DOMException && error.name === "NotAllowedError") {
                    throw new Error("Sign in was canceled.");
                }

                throw error;
            });

            if (!credential) {
                throw new Error("No credential was returned.");
            }

            const result = await this.context.namedCommands.CompleteLogin(JSON.stringify(credential));
            if (!result.Succeeded) {
                throw new Error(result.Error);
            }

            this.setStatus("You're in! Redirecting…", "success");
            window.location.assign("/profile");
        });
    }

    private async run(action: () => Promise<void>): Promise<void> {
        if (this.busy) {
            return;
        }

        this.busy = true;
        try {
            this.ensureSupport();
            this.setStatus("Follow the browser instructions.", "busy");
            await action();
        } catch (error) {
            const message = error instanceof Error ? error.message : "The operation failed.";
            this.setStatus(message, "error");
        } finally {
            this.busy = false;
        }
    }

    private ensureSupport(): void {
        if (!window.isSecureContext ||
            !window.PublicKeyCredential ||
            !PublicKeyCredential.parseCreationOptionsFromJSON ||
            !PublicKeyCredential.parseRequestOptionsFromJSON ||
            !PublicKeyCredential.prototype.toJSON) {
            throw new Error("Use HTTPS and a browser with WebAuthn support.");
        }
    }

    private setStatus(message: string, state: "busy" | "error" | "success"): void {
        // The mascot styles in app.css react to this state.
        document.documentElement.dataset.passkey = state;

        const element = document.querySelector("[data-passkey-status]");
        if (element) {
            element.textContent = message;
        }
    }
}
