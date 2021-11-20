
using SR36_2020_POP2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class RegisteredUser : IUserEditor, ITrainingEditor
{

    public RegisteredUser(string name, string lastName, long jmbg, EGender gender, Address address,
	 string email, string password)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Jmbg = jmbg;
        this.Gender = gender;
        this.Address = address;
        this.Email = email;
        this.Password = password;
        Deleted = false;
    }

    private string Name { get; set; }

    private string LastName { get; set; }

    private long Jmbg { get; set; }

    private EGender Gender { get; set; }

    private Address Address { get; set; }

    private string Email { get; set; }

    private string Password { get; set; }

    private bool Deleted { get; set; }


    public void Modify(string name, string lastName, EGender gender, Address address,
     string email)
    {
        this.Name = name;
        this.LastName=lastName;
        this.Gender = gender;
        this.Address = new Address(id, streetName, streetNum, city, state);
        this.Email = email;
    }

    public void SetDeleted()
    {
        Deleted=true;
    }
    public void ChangePassword(string password)
    { 
        Password=password;
    }


    public abstract void CancelTraining(Training training);
}