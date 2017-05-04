namespace ProjectManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Contracts;

    public class User : IUser 
    {
        public User(string email, string username)
        {
            this.Email = email;
            this.Username = username;
        }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Username is required!")]
        public string Username { get; set; }
      
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Username: " + this.Username);
            builder.AppendLine("    Email: " + this.Email);

            return builder.ToString();
        }
    }
}
