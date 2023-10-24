﻿namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get;}
    
    public string Password { get;}

    public UserCreationDto(string username, string password)
    {
        UserName = username;
        Password = password;
    }
}