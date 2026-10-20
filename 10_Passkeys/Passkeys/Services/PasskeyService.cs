using _10_Passkeys.Models;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace _10_Passkeys.Services;

public sealed class PasskeyService(
    UserManager<ApplicationUser> users,
    SignInManager<ApplicationUser> signIn,
    IHttpContextAccessor httpContextAccessor)
{
    public sealed record OperationResult(bool Succeeded, string? Error = null);

    private HttpContext HttpContext =>
        httpContextAccessor.HttpContext
        ?? throw new InvalidOperationException("An active HTTP request is required.");

    private async Task<ApplicationUser> RequireUserAsync()
    {
        if (HttpContext.User.Identity?.IsAuthenticated != true)
        {
            throw new UnauthorizedAccessException("Authentication is required.");
        }

        return await users.GetUserAsync(HttpContext.User)
            ?? throw new UnauthorizedAccessException("The current account no longer exists.");
    }

    [AllowStaticCommand]
    public async Task<string> GetRegistrationOptions()
    {
        var user = await RequireUserAsync();
        var userId = await users.GetUserIdAsync(user);
        var userName = await users.GetUserNameAsync(user) ?? "User";

        return await signIn.MakePasskeyCreationOptionsAsync(new()
        {
            Id = userId,
            Name = userName,
            DisplayName = userName
        });
    }

    [AllowStaticCommand]
    public async Task<OperationResult> CompleteRegistration(string credentialJson, string deviceName)
    {
        var user = await RequireUserAsync();
        if (string.IsNullOrWhiteSpace(deviceName) || deviceName.Length > 100)
        {
            return new(false, "Device name is required and must not exceed 100 characters.");
        }

        var result = await signIn.PerformPasskeyAttestationAsync(credentialJson);

        if (!result.Succeeded)
        {
            return new(false, "Passkey registration failed.");
        }

        var currentUserId = await users.GetUserIdAsync(user);
        if (!string.Equals(result.UserEntity.Id, currentUserId, StringComparison.Ordinal))
        {
            return new(false, "The account changed during registration.");
        }

        result.Passkey.Name = deviceName.Trim();
        var stored = await users.AddOrUpdatePasskeyAsync(user, result.Passkey);

        return stored.Succeeded
            ? new(true)
            : new(false, "Could not store the passkey.");
    }

    [AllowStaticCommand]
    public Task<string> GetLoginOptions() => signIn.MakePasskeyRequestOptionsAsync(user: null);

    [AllowStaticCommand]
    public async Task<OperationResult> CompleteLogin(string credentialJson)
    {
        var result = await signIn.PasskeySignInAsync(credentialJson);
        return result.Succeeded
            ? new(true)
            : new(false, "Passkey sign-in failed.");
    }
}
