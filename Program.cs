using Kajak_Kenu;
using System.Linq;

List<Kolcsonzes> kolcsonzesek = new();
string path = @"../../../src";

using StreamReader sr = new(
    path: $"{path}/kolcsonzes.txt",
    encoding: System.Text.Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) kolcsonzesek.Add(new(sr.ReadLine()));

Console.WriteLine($"4. feladat:\nÖsszesen {kolcsonzesek.Count} db kölcsönzés adatai találhatók a forrásban");

Console.WriteLine("\n5. feladat:\nAdja meg a keresett személyt:");
string keresett = Console.ReadLine();
var keresettKolcsonzes = kolcsonzesek.Where(k => k.Nev.Contains(keresett.Split(' ')[0]) && k.Nev.Contains(keresett.Split(' ')[1])).ToList();
if (keresettKolcsonzes.Count() == 0) Console.WriteLine("Ez a személy nem kölcsönzött");
else
{
    Console.WriteLine("Az illető kölcsönzései:");
    foreach (var item in keresettKolcsonzes)
    {
        Console.WriteLine($"{item.ElvitelOra}:{item.ElvitelPerc} - {item.VisszahozatalOra}:{item.VisszahozatalPerc}");
    }
}


Console.WriteLine("\n6. feladat:");
var magyarok = kolcsonzesek.Where(k => !k.Nev.Contains(",")).ToList().Count();
var kulfoldi = kolcsonzesek.Where(k => k.Nev.Contains(",")).ToList().Count();
Console.WriteLine($"A magyar kölcsönzők száma: {magyarok}\na külföldieké: {kulfoldi}");