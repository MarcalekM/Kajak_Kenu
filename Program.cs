using Kajak_Kenu;

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
var keresettKolcsonzes = kolcsonzesek.Where(k => k.Nev.Contains(keresett.Replace(",", ""))).ToList();
foreach (var item in keresettKolcsonzes)
{
    Console.WriteLine($"");
}


Console.WriteLine("\n6. feladat:");
var magyarok = kolcsonzesek.Where(k => !k.Nev.Contains(",")).ToList().Count();
var kulfoldi = kolcsonzesek.Where(k => k.Nev.Contains(",")).ToList().Count();
Console.WriteLine($"A magyar kölcsönzők száma: {magyarok}\na külföldieké: {kulfoldi}");