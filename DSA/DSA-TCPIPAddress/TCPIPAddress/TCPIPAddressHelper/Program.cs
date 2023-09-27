// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter ipaddress/subnet:");
var addr = Console.ReadLine();
var ip=new TCPIPAddress.IPAddress(addr);

Console.WriteLine($"Network ID:{ip.NetworkID}");
Console.WriteLine($"Subnet Mask:{ip.SubnetOctetString}/{ip.SubnetSuffix}");
Console.WriteLine($"Subnet Decimal:{ip.SubnetDecString}");
Console.WriteLine($"Number of hosts:{ip.NumberOfAddress}");
Console.WriteLine($"Broadcast:{ip.LastAddress}");

