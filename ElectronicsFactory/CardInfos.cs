using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsFactory
{
    public class ClientCardInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ClientCardInfo(int id, string name, string type, string phone, string email)
        {
            Id = id;
            Name = name;
            Type = type;
            Phone = phone;
            Email = email;
        }
    }

    public class PcbCardInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? ImagePath { get; set; }

        public PcbCardInfo(int id, string name, string? description, double price, int quantity, string? imagePath)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            ImagePath = imagePath;
        }
    }

    public class ComponentCardInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Manufacturer { get; set; }
        public int StockQuantity { get; set; }
        public int? PcbCount { get; set; }
        public string? PcbCoordinates { get; set; }

        public ComponentCardInfo(int id, string name, string type, string? manufacturer,
            int stockQuantity, int? pcbCount = null, string? pcbCoordinates = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Type = type;
            Manufacturer = manufacturer;
            StockQuantity = stockQuantity;
            PcbCount = pcbCount;
            PcbCoordinates = pcbCoordinates;
        }
    }

    public class OrderCardInfo
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public OrderCardInfo(int id, string client, string status, double totalAmount, DateTime registrationDate, DateTime? shipmentDate)
        {
            Id = id;
            Client = client;
            Status = status;
            TotalAmount = totalAmount;
            RegistrationDate = registrationDate;
            ShipmentDate = shipmentDate;
        }
    }

    public class MovementCardInfo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        public MovementCardInfo(int id, string type, string? description, DateTime date)
        {
            Id = id;
            Type = type;
            Description = description;
            Date = date;
        }
    }
}
