﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ForgetMeNot.Api.Dto;
using ForgetMeNot.Services;
using System.Text.RegularExpressions;
using static System.Console;

namespace ForgetMeNot.ViewModels;

[ObservableObject]
public partial class CreateAccountViewModel
{
    [ObservableProperty]
    AccountService accountService;

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private string? email;

    [ObservableProperty]
    private string? password;

    [ObservableProperty]
    private string? nameErrorMessage;

    [ObservableProperty]
    private string? emailErrorMessage;

    [ObservableProperty]
    private string? passwordErrorMessage;

    [ObservableProperty]
    private bool showNameErrorMessage;

    [ObservableProperty]
    private bool showEmailErrorMessage;

    [ObservableProperty]
    private bool showPasswordErrorMessage;

    [ObservableProperty]
    private bool enableButton;

    [ObservableProperty]
    private bool isValidName;

    [ObservableProperty]
    private bool isValidEmail;

    [ObservableProperty]
    private bool isValidPassword;

    [ObservableProperty]
    private bool createAccountIsRunning;

    public CreateAccountViewModel(AccountService accountService)
    {
        this.accountService = accountService;
    }

    [RelayCommand]
    async Task SignUp()
    {
        if (EnableButton)
        {
            AccountCreateRequest accountCreateRequest =
                new()
                {
                    Email = this.Email,
                    FullName = Name,
                    PlainPassword = Password
                };

            try
            {
                CreateAccountIsRunning = true;
                await accountService.CreateAccount(accountCreateRequest);
                CreateAccountIsRunning = false;
                await Application.Current!.MainPage!.DisplayAlert(
                    "Sign up completed",
                    "Your account has been created successfully",
                    "Ok"
                );
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception exception)
            {
                CreateAccountIsRunning = false;
                await Application.Current!.MainPage!.DisplayAlert(
                    "Sign up failed",
                    "We were not able to create an account",
                    "Ok"
                );
                WriteLine(exception);
            }
        }
    }

    [RelayCommand]
    public Task ValidateName()
    {
        if (!string.IsNullOrEmpty(Name) && Name.Length >= 2)
        {
            IsValidName = true;
            ShowNameErrorMessage = false;
            EnableButton = IsValidName && IsValidEmail && IsValidPassword;
        }
        else
        {
            NameErrorMessage = "*Please enter a name with at least two characters";
            IsValidName = false;
            ShowNameErrorMessage = true;
            EnableButton = IsValidName && IsValidEmail && IsValidPassword;
        }

        return Task.CompletedTask;
    }

    string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    [RelayCommand]
    public Task ValidateEmail()
    {
        if (!string.IsNullOrEmpty(Email) && Regex.IsMatch(Email, emailPattern))
        {
            IsValidEmail = true;
            ShowEmailErrorMessage = false;
            EnableButton = IsValidName && IsValidEmail && IsValidPassword;
        }
        else
        {
            EmailErrorMessage = "*Invalid email";
            IsValidEmail = false;
            ShowEmailErrorMessage = true;
            EnableButton = IsValidName && IsValidEmail && IsValidPassword;
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task ValidatePassword()
    {
        if (!string.IsNullOrEmpty(Password) && Password.Length >= 6)
        {
            IsValidPassword = true;
            ShowPasswordErrorMessage = false;
            EnableButton = IsValidName && IsValidEmail && IsValidPassword;
        }
        else
        {
            PasswordErrorMessage = "*Invalid password. Must be at least 6 characters";
            IsValidPassword = false;
            ShowPasswordErrorMessage = true;
            EnableButton = IsValidName && IsValidEmail && IsValidPassword;
        }

        return Task.CompletedTask;
    }
}
