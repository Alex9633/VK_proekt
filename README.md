# World's Hardest Game
## Windows Forms рекреирана игра од Александар Миланов
### Објаснување на проблемот
Оваа апликација е рекреација на стара 2D topdown flash игра наречена "World's Hardest Game" што ја имав играно одамна. Оригиналната верзија веќе не постои по затварањето на flash player од Adobe, па има повеќе други рекреации на интернет на повеќе страни.
Играта е премногу едноставна, користејќи само основни фигури за графика со едноставни контроли: горе, долу, лево и десно. Тоа што привлекува е тежината на ниво дизајнот.
Подоле се две рекреации на оригиналната:

https://www.crazygames.com/game/worlds-hardest-game<br/>
https://www.coolmathgames.com/0-worlds-hardest-game
<br/>
<br/>

### Решение на проблемот
По стартувањето на играта (GameForm) се создава нова сцена за секое ниво со соодветните податоци (играч - позиција; граници - позиции и големини; позадина за нивото позиции и големини; цел и старт - позиции и големини; непријатели - позиции, типови и брзини; парички - позиции; вкупен број на deaths).
Сите овие атрибути секој објект самиот си ги чува во себе (својата класа) и по потреба до некои може да се пристапи, пример позициите на играчот или непријателите.
Движењето и проверката за колизии се извржуваат преку тајмери на главниот прозорец. Друго што се чува преку класата на главниот прозорец е моменталното ниво, вкупното време изминато од почетокот на играта и моментален број на deaths после секое ниво.
<br/>
<br/>

### Опишување функции или класи
Повеќето се доста едноствни, плус има објаснувања за **се** во коментари во самиот код.
Пример да земеме класата "Player":
```c#
public class Player
    {
        // create and draw a player in a specific position

        public Point Center { get; set; }
        
        public Player(Point Center) { 
            this.Center = Center;
        }

        public void Draw (Graphics g)
        {
            Brush b = new SolidBrush (Color.Red);
            Pen p = new Pen (Color.DarkRed, 4);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(b, Center.X - 15, Center.Y - 15, 30, 30);
            g.DrawRectangle(p, Center.X - 15, Center.Y - 15, 30, 30);
            b.Dispose();
            p.Dispose();
        }

        public void Move(int dir)   // gets called from Scene.cs, if it's a legal move it updates the position
        {
            switch (dir) {
                case 1: Center = new Point(Center.X, Center.Y - 3); break;
                case 2: Center = new Point(Center.X, Center.Y + 3); break;
                case 3: Center = new Point(Center.X - 3, Center.Y); break;
                case 4: Center = new Point(Center.X + 3, Center.Y); break;
            }
        }
    }
```
Чува само позиција на центарот на играчот. Првиот метод ```Player(Point Center)``` создава нов објект од типот играч со дадени координати, вториот метод ```void Draw (Graphics g)``` го црта играчот на дадените координати, а третиот метод ```void Move(int dir)``` го поместува играчот. Тој е повикан од класата ```Scene``` која содржи метод што проверува дали на наредната позиција има колизија со границите на нивото. Овој метод исто така е повикан од ```GameForm``` класата која проверува дали играчот ги држи некои од стрелките за движење и на секоj timer tick ако држи го активира овој процес за проверка на колизија и движење (dir: 1 - горе, 2 - доле, 3 - лево, 4 - десно).
<br/>
<br/>

### Screenshots и упатство
Main Menu, Instructions, Level Select и Завршен екран:
<ul>
<li>
    https://github.com/Alex9633/WorldsHardestGame/assets/120327803/60c4de62-e85c-4cc3-a428-ea72c7093682
    https://github.com/Alex9633/WorldsHardestGame/assets/120327803/1ea871e3-ca60-4497-a417-555dc665738c
    https://github.com/Alex9633/WorldsHardestGame/assets/120327803/3302145a-824d-48db-9948-5c0b3fc89e77
    https://github.com/Alex9633/WorldsHardestGame/assets/120327803/fb9e9cca-e38b-4edf-ada4-e469055c3d66
</li>
</ul>

Слики од gameplay:
<ul>
<li>
    https://github.com/Alex9633/WorldsHardestGame/assets/120327803/1fb2b7fb-11cb-4204-85f3-3da3da00d38f
    https://github.com/Alex9633/WorldsHardestGame/assets/120327803/0786164c-9393-4e83-b3e6-2aa033704df0
</li>
</ul>

**Упатство:**
Многу едноставна игра, вие сте црвената коцка, треба да ги соберете сите парички (жолти кругови) и избегнете плавите кругови. Кога ќе ги соберете сите парички и допрете до целта, ќе продолжите на наредно ниво од вкупно 6. Се движите со стрелките. Ако допрете плав круг се ресетира нивото и deaths бројачот се зголемува за 1. Играта ви ги брои deaths и вкупното време додека поминете ниво 6.
<ul>
  <li>Main Menu: Play game -> Instructions Window;  Level Select -> Level Select Window;  Quit -> гаси апликацијата</li>
  <li>Instructions Window: Begin -> почнува играта од ниво 1;  Back -> се враќа на Main Menu</li>
  <li>Level Select Window: Level X -> почнува од X ниво;  Back -> се враќа на Main Menu</li>
  <li>Завршен екран: Back to Menu -> се враќа на Main Menu</li>
</ul>
