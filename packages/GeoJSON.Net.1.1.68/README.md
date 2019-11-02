[![NuGet Version](http://img.shields.io/nuget/v/GeoJSON.NET.svg?style=flat)](https://www.nuget.org/packages/GeoJSON.NET/) 
[![Build status](https://ci.appveyor.com/api/projects/status/n4q1opb6dod0hwac?svg=true)](https://ci.appveyor.com/project/matt-lethargic/geojson-net)

## *** Notice ***
A quick note... sorry to everyone who has been following or using this project over t
 last year, I started a new role a year ago and it took some time away from this project, when that calmed down I actually got locked out of my GitHub account and as it had two factor authentication on it was not an easy task getting back in. This is all sorted now and I'm going to be starting back on this project now. 
MattLethargic, Aug '18

# GeoJSON.NET
GeoJSON.Net is a .NET library for the [RFC 7946 The GeoJSON Format](https://tools.ietf.org/html/rfc7946) and it uses and provides [Newtonsoft Json.NET](http://json.codeplex.com) converters for serialization and deserialization of GeoJSON data.


## Installation & Usage

[GeoJSON.Net NuGet package](https://www.nuget.org/packages/GeoJSON.Net/):
`Install-Package GeoJSON.Net`

### Serialization

```csharp
Position position = new Position(51.899523, -2.124156);
Point point = new Point(position);

string json = JsonConvert.SerializeObject(point);
```

### Deserialization

```csharp
string json = "{\"coordinates\":[-2.124156,51.899523],\"type\":\"Point\"}";

Point point = JsonConvert.DeserializeObject<Point>(json);
```

See the [Tests](https://github.com/GeoJSON-Net/GeoJSON.Net/tree/master/src/GeoJSON.Net.Tests) for more examples.


## News
It's probably best to check out the [commits](https://github.com/GeoJSON-Net/GeoJSON.Net/commits/master) 
and the [issues](https://github.com/GeoJSON-Net/GeoJSON.Net/issues) what has been added over time.

## Contributing
Highly welcome! Just fork away and send a pull request. We try and review most pull requests within a couple of days. There is now a version 2.0.0 branch. I've created this ready for any breaking changes and any extra features and would encourage anything that isn't a bug fix to go in there.

## Thanks
This library would be NOTHING without its [contributors](https://github.com/GeoJSON-Net/GeoJSON.Net/graphs/contributors) - thanks so much!!

## Sponsors

 We have the awesome .NET tools from [JetBrains](http://www.jetbrains.com/).

[![Resharper](http://www.filehelpers.net/images/tools_resharper.gif)](http://www.jetbrains.com/resharper/)
