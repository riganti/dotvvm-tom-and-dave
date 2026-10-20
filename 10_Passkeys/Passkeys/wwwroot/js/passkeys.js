export default (context) => new PasskeysModule(context);
class PasskeysModule {
    context;
    busy = false;
    constructor(context) {
        this.context = context;
    }
    async passkeyRegister(deviceName) {
        await this.run(async () => {
            if (!deviceName?.trim() || deviceName.length > 100) {
                throw new Error("Device name is required and must not exceed 100 characters.");
            }
            const optionsJson = await this.context.namedCommands.GetRegistrationOptions();
            const publicKey = PublicKeyCredential.parseCreationOptionsFromJSON(JSON.parse(optionsJson));
            const credential = await navigator.credentials.create({ publicKey });
            if (!credential) {
                throw new Error("No credential was returned.");
            }
            const result = await this.context.namedCommands.CompleteRegistration(JSON.stringify(credential), deviceName);
            if (!result.Succeeded) {
                throw new Error(result.Error);
            }
            window.location.assign("/profile/security");
        });
    }
    async passkeyLogin() {
        await this.run(async () => {
            const optionsJson = await this.context.namedCommands.GetLoginOptions();
            const publicKey = PublicKeyCredential.parseRequestOptionsFromJSON(JSON.parse(optionsJson));
            const credential = await navigator.credentials.get({ publicKey }).catch((error) => {
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
            window.location.assign("/profile");
        });
    }
    async run(action) {
        if (this.busy) {
            return;
        }
        this.busy = true;
        try {
            this.ensureSupport();
            this.setStatus("Follow the browser instructions.");
            await action();
        }
        catch (error) {
            const message = error instanceof Error ? error.message : "The operation failed.";
            this.setStatus(message);
        }
        finally {
            this.busy = false;
        }
    }
    ensureSupport() {
        if (!window.isSecureContext ||
            !window.PublicKeyCredential ||
            !PublicKeyCredential.parseCreationOptionsFromJSON ||
            !PublicKeyCredential.parseRequestOptionsFromJSON ||
            !PublicKeyCredential.prototype.toJSON) {
            throw new Error("Use HTTPS and a browser with WebAuthn support.");
        }
    }
    setStatus(message) {
        const element = document.querySelector("[data-passkey-status]");
        if (element) {
            element.textContent = message;
        }
    }
}
//# sourceMappingURL=passkeys.js.map