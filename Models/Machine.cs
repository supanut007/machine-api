using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MachineMaster.Models;

public partial class Machine
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Machine No is required.")]
    public string MachineNo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Machine Name is required.")]
    public string MachineName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Plant is required.")]
    public string Plant { get; set; } = string.Empty;

    public string? Status { get; set; }
}
