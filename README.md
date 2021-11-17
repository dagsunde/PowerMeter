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

I have hardcoded my Net-Tarrif inside the HomeController:
```c#
        public IActionResult Index()
        {

            string fileName = "PowerReading.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            PowerModel model = JsonSerializer.Deserialize<PowerModel>(jsonString);

            <b>var gridCost = model.consumption * 0.385M;</b>
            model.cost += gridCost;
            return View(model);
        }
```
