using PushR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PushR.ViewModels
{
  public class LoginPageVM : ViewModelBase
  {
    bool block;
    private string _name;
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        SetProperty(ref _name, value);
        LoginCmd.ChangeCanExecute();
      }
    }
    private string _pwd;
    public string Pwd
    {
      get
      {
        return _pwd;
      }
      set
      {
        SetProperty(ref _pwd, value);
        LoginCmd.ChangeCanExecute();
      }
    }
    private string _nickname;
    public string NickName
    {
      get
      {
        return _nickname;
      }
      set
      {
        SetProperty(ref _nickname, value);
        LoginCmd.ChangeCanExecute();
      }
    }
    public Command LoginCmd { get; private set; }
    public LoginPageVM()
    {
      LoginCmd = new Command(ExecuteLoginCmd, CanClick);
      block = false;
    }
    async void ExecuteLoginCmd()
    {
      if (block)
      return;
      
      block = true;
      var md5 = GenerateMD5(_pwd);
      UserModel model = new UserModel
      {
        Name = _name,
        Password = md5,
        NickName = _nickname
      };
      //var result = await Services.Services.Register(model);
    }
    private bool CanClick()
    {
      return (!string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_pwd) && !string.IsNullOrEmpty(_nickname));
    }
    public static string GenerateMD5(string input)
    {
      using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
      {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
          sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
      }
    }
  }
}
