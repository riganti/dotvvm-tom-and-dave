# Passkeys demo

This .NET 10 DotVVM application uses ASP.NET Core Identity with SQLite. Identity stores use schema version 3, and `PasskeyService` exposes the server-side registration and authentication ceremonies to DotVVM static commands.

Pages are registered in `DotvvmStartup.cs`. The browser WebAuthn orchestration is in `Resources/Scripts/passkeys.ts`; it calls named static commands and redirects after a successful ceremony. It also sets `data-passkey="busy|error|success"` on `<html>` so the character can react.

## UI

The UI uses DotVVM Tailwind controls, branded around the RIGANTI character (navy `#103A55`, mint `#39E58E`).

* `Pages/AuthLayout.dotmaster` is the split-screen shell for sign-in and create-account (`MascotSays` and `MainContent` placeholders). `Pages/Layout.dotmaster` is the signed-in shell with a top menu.
* `Controls/Mascot` (`<cc:Mascot>`) renders the character as inline SVG. Size it with a CSS class; add `mascot-framed` for the navy badge, `mascot-float` or `mascot-hop` for motion.
* `Controls/PageHero` (`<cc:PageHero Title Subtitle MascotSays>`) is the navy page header; content follows in `<div class="page-body">`.
* `Resources/Styles/app.css` re-themes the controls by overriding their `--color-*-rgb` variables and classes. The controls' CSS lives in earlier cascade layers, so rules in this file's `base`/`components` layers win. The build compiles it with Tailwind into `wwwroot/css/app.css`; run `npm run build-css` in `Passkeys` after editing it while the app is running.

Run `dotnet build 10_Passkeys\Passkeys.slnx` from the repository root to build the solution. The project is in `Passkeys\10_Passkeys.csproj`. The SQLite demo database is created automatically as `passkeys-demo.db` on application startup.
