# Passkeys demo

This .NET 10 DotVVM application uses ASP.NET Core Identity with SQLite. Identity stores use schema version 3, and `PasskeyService` exposes the server-side registration and authentication ceremonies to DotVVM static commands.

Pages are registered in `DotvvmStartup.cs`. The browser WebAuthn orchestration is in `Resources/Scripts/passkeys.ts`; it calls named static commands and redirects after a successful ceremony.

Run `dotnet build 10_Passkeys\Passkeys.slnx` from the repository root to build the solution. The project is in `Passkeys\10_Passkeys.csproj`. The SQLite demo database is created automatically as `passkeys-demo.db` on application startup.
