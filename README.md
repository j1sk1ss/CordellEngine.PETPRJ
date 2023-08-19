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
<h1 align="center"> Lightning </h1>
<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Seven.gif">
</p>

-----------------------------------
<h1 align="center"> Example of geometry in moving </h1>
<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Second.gif">
</p>

-----------------------------------
<h1 align="center"> 3D planing on scene </h1>
<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Fourth.gif">
</p>

-----------------------------------
<h1 align="center"> Color functionality </h1>

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

<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Third.gif">
</p>

Don`t foget to use **COLOR CAMERA** instead **CHROME CAMERA**

-----------------------------------
<h1 align="center"> Collisions, spawning and deleting </h1>

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

<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Fives.gif">
</p>

-----------------------------------
<h1 align="center"> Collections </h1>

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


<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Six.gif">
</p>

-----------------------------------
<h1 align="center"> Lines </h1>

But if u dont want to use preset objects like **SPHERE** or **CUBE** with **PLANE**, u can create ur own object with **LINES** united into **COLLECTION**. Next code will return next scene:

      public static void Main() {
              Console.CursorVisible = false;
      
              var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0)), 
                  new List<Object> {
                      new Collection(new Vector3(0), new Vector3(1), new List<Object> {
                          new Line(new Vector3(-1.8, -1, 1), new Vector3(-1.8, 1, 1)),
                          new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, 1, 0)),
                      
                          new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, -1, -1)),
                          new Line(new Vector3(-1.8, -3, 0), new Vector3(-1.8, -3, -1)),
                      
                          new Line(new Vector3(0, -1, 1), new Vector3(0, 1, 1)),
                          new Line(new Vector3(0, -1, 0), new Vector3(0, 1, 0)),
                      
                          new Line(new Vector3(0, -1, 0), new Vector3(0, -1, -1)),
                          new Line(new Vector3(0, -3, 0), new Vector3(0, -3, -1)),
                      })
                  });
      
              var t = 0;
              while (true) {
                  t++;
                  space.GetView();
                  
                  space.GetObject("collection1").SetPosition(new Vector3(Math.Cos(t * .01), -Math.Cos(t * .01), Math.Sin(t * .01)));
              }
      }

<p align="center">
  <img width="800" height="480" src="https://github.com/j1sk1ss/SharpEngine.EXMPL/blob/master/Eight.gif">
</p>

-----------------------------------
