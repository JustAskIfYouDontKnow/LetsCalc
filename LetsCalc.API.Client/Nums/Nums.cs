using System.ComponentModel.DataAnnotations;

namespace LetsCalc.API.Client.Nums;

public class Nums
{
    public int A { get; set; }
    public int B { get; set; }
    
    
    public class Response
    {
        [Required]
        public int Sum { get; }
            
        public Response(int sum)
        {
            Sum = sum;
        }
    }
}