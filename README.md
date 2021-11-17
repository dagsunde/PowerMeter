# PowerMeter
Simple Naive C# website showing consumption data from the Tibber API

Note that you have to get your Tibber acces token here: https://developer.tibber.com/settings/accesstoken.
and put it into appsettings.json

```javascript
{
    "Tokens": {
    "TibberToken": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
  },

}
```

I have hardcoded my Grid Cost inside the HomeController:
```c#
        public IActionResult Index()
        {

            string fileName = "PowerReading.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            PowerModel model = JsonSerializer.Deserialize<PowerModel>(jsonString);

            var gridCost = model.consumption * 0.385M;
            model.cost += gridCost;
            return View(model);
        }
```

The realtime feed subscription is started in Program.cs, and just serialie the data to disk,
where the homecontroller picks them up.
