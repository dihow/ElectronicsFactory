using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsFactory
{
    // Существующие классы (оставляем как есть)
    public class Client
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Inn { get; set; }

        public Client(int id, string type, string phone, string email, string inn)
        {
            Id = id;
            Type = type;
            Phone = phone;
            Email = email;
            Inn = inn;
        }
    }

    public class Individual
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }

        public Individual(int clientId, string fullName, string address, int age)
        {
            ClientId = clientId;
            FullName = fullName;
            Address = address;
            Age = age;
        }
    }

    public class LegalEntity
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string? ContactPerson { get; set; }
        public string? LegalAddress { get; set; }
        public string? ActualAddress { get; set; }

        public LegalEntity(int clientId, string companyName, string contactPerson, string legalAddress, string actualAddress)
        {
            ClientId = clientId;
            CompanyName = companyName;
            ContactPerson = contactPerson;
            LegalAddress = legalAddress;
            ActualAddress = actualAddress;
        }
    }

    // Новые сущности для остальных таблиц

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public Employee(int id, string fullName, string address, string phone, string email,
                       string position, decimal salary, string login, string passwordHash, DateTime createdAt)
        {
            Id = id;
            FullName = fullName;
            Address = address;
            Phone = phone;
            Email = email;
            Position = position;
            Salary = salary;
            Login = login;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
        }
    }

    public class Pcb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string? Batch { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public int? LayersCount { get; set; }
        public string? Comment { get; set; }
        public string? ImagePath { get; set; }

        public Pcb(int id, string name, string serialNumber, string? batch, string? description,
                  decimal price, int totalQuantity, DateTime? manufactureDate,
                  decimal? length, decimal? width, int? layersCount, string? comment, string? imagePath)
        {
            Id = id;
            Name = name;
            SerialNumber = serialNumber;
            Batch = batch;
            Description = description;
            Price = price;
            TotalQuantity = totalQuantity;
            ManufactureDate = manufactureDate;
            Length = length;
            Width = width;
            LayersCount = layersCount;
            Comment = comment;
            ImagePath = imagePath;
        }
    }

    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public Component(int id, string name, string? manufacturer, decimal price,
                        string type, int stockQuantity, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Type = type;
            StockQuantity = stockQuantity;
            CreatedAt = createdAt;
        }
    }

    // Добавьте в Entities.cs
    public class ComponentSpecification
    {
        // Константы для типов спецификаций
        public const string RESISTANCE = "Сопротивление";
        public const string TOLERANCE = "Допуск";
        public const string POWER = "Мощность";
        public const string CAPACITANCE = "Ёмкость";
        public const string VOLTAGE = "Напряжение";
        public const string MAX_TEMPERATURE = "Максимальная температура";
        public const string VOLTAGE_DROP = "Падение напряжения";
        public const string REVERSE_VOLTAGE = "Обратное напряжение";
        public const string FORWARD_CURRENT = "Прямой ток";

        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string Specification { get; set; }
        public string SpecificationValue { get; set; }

        public ComponentSpecification(int id, int componentId, string specification, string specificationValue)
        {
            Id = id;
            ComponentId = componentId;
            Specification = specification;
            SpecificationValue = specificationValue;
        }
    }

    public class PcbComponent
    {
        public int PcbId { get; set; }
        public int ComponentId { get; set; }
        public int ComponentCount { get; set; }
        public string? Coordinates { get; set; }

        public PcbComponent(int pcbId, int componentId, int componentCount, string? coordinates)
        {
            PcbId = pcbId;
            ComponentId = componentId;
            ComponentCount = componentCount;
            Coordinates = coordinates;
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string? TransportCompany { get; set; }

        public Order(int id, int clientId, DateTime registrationDate, string status,
                    decimal totalAmount, DateTime? shipmentDate, string? transportCompany)
        {
            Id = id;
            ClientId = clientId;
            RegistrationDate = registrationDate;
            Status = status;
            TotalAmount = totalAmount;
            ShipmentDate = shipmentDate;
            TransportCompany = transportCompany;
        }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PcbId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerPcb { get; set; }

        public OrderItem(int id, int orderId, int pcbId, int quantity, decimal pricePerPcb)
        {
            Id = id;
            OrderId = orderId;
            PcbId = pcbId;
            Quantity = quantity;
            PricePerPcb = pricePerPcb;
        }
    }

    public class Movement
    {
        public int Id { get; set; }
        public string MovementType { get; set; }
        public string ProductType { get; set; }
        public string? Description { get; set; }
        public int Value { get; set; }
        public DateTime MovementDate { get; set; }

        public Movement(int id, string movementType, string productType, string? description,
                       int value, DateTime movementDate)
        {
            Id = id;
            MovementType = movementType;
            ProductType = productType;
            Description = description;
            Value = value;
            MovementDate = movementDate;
        }
    }

    public enum ComponentType
    {
        Resistor,
        Capacitor,
        Diode,
        Transistor,
        Microcontroller,
        Other
    }
}