# DE-PTI Magas szintű programozási nyelvek 2 tárgy féléves projekt tárolója

## A projektről röviden: 
### **Blackjack kártyajáték**

#### A Blackjack célja

A Blackjack legfontosabb szabálya, hogy a játékmenet során a játékosnál lévő lapok összértéke több legyen az osztó lapjainak összértékénél, anélkül, hogy meghaladná a 21-et.

A Blackjack-et a hagyományos és online kaszinókban maximum 8 pakli, 52 lapos francia kártyával játsszák. Az osztónak minden esetben meg kell állnia 17-nél, ezt nevezzük Soft 17-nek.

#### A lapok értékei

    2–10-ig a kártyák annyit érnek, amennyi a névértékük.
    A Bubi, Dáma és Király értéke 10.
    Az ász értéke lehet 1 vagy 11, amelyik előnyösebb a kéz szempontjából.

#### Alapszabályok

Az Blackjackban egy osztó és maximum hét játékos játszik. A projektemben megírt játék egy osztóra és egy játékosra lesz optimalizálva.  

A játék kezdetén az osztó a játékosnak oszt egy lapot, lapjával felfordítva, ezután pedig magának. Az osztó ezután osztja ki a második lapot felfordítva a játékosnak, azonban az osztó második lapja lefelé fordítva kerül kiosztásra. Ezután a játékos eldönti, hogy szeretne-e még kérni az osztótól egy vagy több lapot. A játékos egészen addig kérhet lapot, amíg azok összértéke nem haladja a 21-et, vagy megtalálja a lehető legjobb kezet. A kezdeti kezek értéke a lapok mellett jelenik meg.

Amikor a lapok összértéke meghaladja a 21-et, azt nevezik besokallásnak, ebben az esetben a játékos elveszíti a kört. Miután ez megtörtént, az osztó magának is oszt lapot. Ezt szigorú szabályok szerint teheti meg, amelyek eltérőek lehetnek annak függvényében, hogy épp melyik változatát játsszák a Blackjack-nek.

#### Eredmények

A játékos akkor nyer, ha a végső kezének értéke közelebb van a 21-hez, mint az osztóé, vagy ha az osztó besokallt.

Ha az első két lap összege pontosan 21, akkor valósul meg a legjobb kéz, vagyis a Blackjack, amely verhetetlen. A Blackjack Ászból, valamint bármilyen tízes értékű lapból áll.
Döntetlenről akkor beszélünk, ha az osztónak szintén Blackjack-je van.
