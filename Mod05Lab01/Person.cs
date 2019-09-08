public class Person
{

    // Fields
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public string Mobile { get; set;}
    public string Email { get; set;}

    // Constructors
    public Person()
    {

    }
    public Person(string FirstName, string LastName, string Mobile, string Email)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Mobile = Mobile;
        this.Email = Email;
    }

    // Setters
    public void setFirstName(string FirstName)
    {
        this.FirstName = FirstName;
    }

    public void setLastName(string LastName)
    {
        this.LastName = LastName;
    }

    public void setMobile(string Mobile)
    {
        this.Mobile = Mobile;
    }

    public void setEmail(string Email)
    {
        this.Email = Email;
    }

    // Getters
    public string getFirstName()
    {
        return this.FirstName;
    }

    public string getLastName()
    {
        return this.LastName;
    }

    public string getMobile()
    {
        return this.Mobile;
    }

    public string getEmail()
    {
        return this.Email;
    }
}