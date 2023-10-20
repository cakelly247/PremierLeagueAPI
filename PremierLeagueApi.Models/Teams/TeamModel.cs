using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
namespace PremierLeagueApi.Models;

public class TeamModel
{
[Required]
public string TeamName {get; set;} = string.Empty;

[MaxLength(100)]
public string City { get; set; } = string.Empty;

[Range(0, int.MaxValue)]
public int Wins {get; set;}

[Range(0, int.MaxValue)]
public int Losses {get; set;}



}