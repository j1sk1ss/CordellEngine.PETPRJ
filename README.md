# Cordell Engine
Simple library for implementing 3D graphics anywhere

# Simple creation of objects
      var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0)), 
          new List<Object> {
              new Sphere(new Vector3(0, 3, 0), new Vector3(1), Material.DefaultMaterial, "sphere_1"),
              new Sphere(new Vector3(0, -3, 0), new Vector3(1), Material.DefaultMaterial, "sphere_2"),
              new Light(new Vector3(-1, 0, -1), 1, "light1_1")
          });

-----------------------------------
## Lighting 
![Alt Text](https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Seven.gif)

-----------------------------------
## Example of geometry in moving
![Alt Text](https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Second.gif)

-----------------------------------
## 3D planing on scene
![Alt Text](https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Fourth.gif)

-----------------------------------
## Color functionality
Every object ob scene have **MATERIAL** parametr with next constructors:

    public Material(string gradient) {
        Gradient = gradient;
        ConsoleColor = ConsoleColor.White;
    }

    public Material(ConsoleColor color) {
        Gradient     = " .:!/r(l1Z4H9W8$@";
        ConsoleColor = color;
    }

    public Material(string gradient, ConsoleColor color) {
        Gradient     = gradient;
        ConsoleColor = color;
    }

![Alt Text](https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Third.gif)

Don`t foget to use **COLOR CAMERA** instead **CHROME CAMERA**

-----------------------------------
## Collisions, spawning and deleting
U also can **SPAWN**, **DELETE** and check **COLLISIONS** of objects in space. For example next code:

    public static void Main() {
        Console.CursorVisible = false;
    
        var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0)), 
            new List<Object> {
                new Sphere(new Vector3(0, 3, 0), new Vector3(1), Material.DefaultMaterial, "sphere_1"),
                new Sphere(new Vector3(0, -3, 0), new Vector3(1), Material.DefaultMaterial, "sphere_2"),
                new Light(new Vector3(-1, 0, -1), 1, "light1_1")
            });
    
        var t = 0;
        while (true) {
            t++;
            space.GetView();
            space.GetObject("new_sphere").SetPosition(new Vector3(Math.Sin(t * .01), 0, Math.Cos(t * .01)));
            
            
            space.GetObject("sphere_2").Move(new Vector3(0,.0010,0));
            if (space.GetObject("sphere_1").CollisionObjects(space.Objects).Count > 0)
            {
                space.DeleteObject("sphere_1");
                space.CreateObject(new Sphere(new Vector3(0), new Vector3(1), Material.DefaultMaterial, "new_sphere"));
            }
        }
    }

Will return next scene:

![Alt Text](https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Fives.gif)

-----------------------------------
## Collections
U can unite objects into collections and work with them. First for this u should create collection and add some objects:

      var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0)), 
            new List<Object> {
                new Collection(new Vector3(0), new Vector3(0), new List<Object> {
                    new Sphere(new Vector3(0, 2, 0), new Vector3(1), Material.DefaultMaterial, "sphere_1"),   
                    new Sphere(new Vector3(0, -2, 0), new Vector3(1), Material.DefaultMaterial, "sphere_2"),   
                }),
                new Light(new Vector3(-1, 0, -1), 1, "light_1")
      });

And next code will return next scene:

      var t = 0;
      while (true) {
            t++;
            space.GetView();

            space.GetObject("light_1").SetPosition(new Vector3(Math.Cos(t * .01), Math.Sin(t * .01),-1));
            space.GetObject("collection1").SetPosition(new Vector3(0, 0,Math.Sin(t * .01)));
      }


![Alt Text](https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Six.gif)
