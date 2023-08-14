using TaskManagement.Shared;

namespace TaskManagement.Model;

public class Product:BaseEntity,IEntity

{
    public string ProdcutName { get; set; } =string.Empty;
    public double ProductPrice { get; set; } 
    public string ProductModel { get; set; }=string.Empty;
    public int Id { get; set; }
}

   // Note :need Add Reference to Tastk?Management to taskmanagement.model of taskmanagement .shared;//
  // step: click the right buttom on taskmanagemnet .model-> add->project referance->select Taskmanagement .shared; //