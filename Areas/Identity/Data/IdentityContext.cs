using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FRIDGamE.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<FRIDGamEUser>
{

    public DbSet<Game> Games { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<FRIDGamEUser> Users { get; set; }
    public DbSet<News> News { get; set; }
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<FRIDGamEUser>()
            .HasMany(e => e.News)
            .WithOne(e => e.Author);
        builder.Entity<FRIDGamEUser>()
            .HasMany(e => e.Games)
            .WithMany(e => e.Owners);

        builder.Entity<Developer>().HasData(
            new Developer() { Id = 1, DeveloperName = "Yacoper", NIP = "4209342137" },
            new Developer() { Id = 2, DeveloperName = "Rockstar North", NIP = "4403144050" },
            new Developer() { Id = 3, DeveloperName = "Rockstar Games", NIP = "4403144051" },
            new Developer() { Id = 4, DeveloperName = "CD Projekt Red", NIP = "9111129970" },
            new Developer() { Id = 5, DeveloperName = "Ubisoft", NIP = "0048997663" },
            new Developer() { Id = 6, DeveloperName = "Techland", NIP = "4925793530" },
            new Developer() { Id = 7, DeveloperName = "Frozen District", NIP = "7792453949" }
            );

        builder.Entity<Publisher>().HasData(
            new Publisher() { Id = 1, PublisherName = "ZSHT", NIP = "7361066403" },
            new Publisher() { Id = 2, PublisherName = "Yacoper INC", NIP = "3503493043" },
            new Publisher() { Id = 3, PublisherName = "Take-Two Interactive", NIP = "2095394934" },
            new Publisher() { Id = 4, PublisherName = "CDPR", NIP = "2450923585" },
            new Publisher() { Id = 5, PublisherName = "Ubisoft", NIP = "2590358583" },
            new Publisher() { Id = 6, PublisherName = "Techland", NIP = "2094672468" },
            new Publisher() { Id = 7, PublisherName = "PlayWay", NIP = "5213609756" }
            );

        builder.Entity<Game>().HasData(
                new Game()
                {
                    Id = 1,
                    GameName = "Lorem Ipsum",
                    Description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vehicula ac sem ut semper. Curabitur auctor, nibh eu dictum consequat, sapien tellus condimentum sem, et pulvinar nisl nunc sit amet leo. Nam in velit vitae neque mollis sodales quis at diam. Nunc placerat elit tellus, id iaculis nisl commodo quis. Maecenas ac neque tortor. Phasellus eget nisi vel arcu lobortis tempus at non felis. Nulla finibus magna vel eros pretium, sed eleifend diam porta. Integer pellentesque lacus sollicitudin ligula porta finibus. Nullam ornare et sapien a tincidunt. Nullam quam libero, congue sit amet velit eu, suscipit sagittis neque. Aliquam at luctus sem. Nullam ut feugiat elit, tempor dignissim leo. Maecenas sit amet dui augue. Donec bibendum laoreet turpis, et rhoncus diam iaculis sed. Morbi tincidunt erat at ligula congue, ut vestibulum arcu vehicula. Phasellus vitae vestibulum mi.\r\n\r\nSed tristique lectus non nibh vehicula, vel tempor augue ornare. Fusce at lacus vitae libero congue auctor ut in massa. Nunc id neque magna. Integer nec tellus et ante tempus laoreet sit amet vitae leo. Curabitur ut lacus ut lorem feugiat fringilla. Pellentesque ac ornare neque, ut tincidunt orci. Cras tristique scelerisque vulputate. In pulvinar porta odio, non scelerisque elit sagittis non. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur laoreet fringilla malesuada. Cras cursus arcu felis, a scelerisque urna ullamcorper quis. Praesent facilisis, nulla a elementum fermentum, dui nisl mollis ipsum, auctor maximus ligula ipsum et justo. Morbi ac ex a nulla fermentum sollicitudin. Aenean tempus eros venenatis semper rutrum. In quis tempor nunc, ac efficitur enim. Proin malesuada ex eget elit venenatis, ut suscipit dui auctor. ",
                    GamePublisherId = 1,
                    StudioId = 1,
                    RegularPrice = 0,
                    ReleaseDate = new DateTime(2021, 4, 5)
                },
                new Game()
                {
                    Id = 2,
                    GameName = "The Variant",
                    Description = "“New Hope” to nazwa projektu opracowanego przez Dr Stephena Wilsona, genialnego naukowca który w celu uratowania ludzkości przed zagładą, postanawia stworzyć symulację. Celem eksperymentu jest utworzenie rewolucji w łączeniu ludzi z maszynami aby uratować ludzkość. Tak właśnie powstały Varianty, twory które odporne byłyby na jakikolwiek rodzaj chorób. Niestety eksperyment nie poszedł zgodnie z planem Doktora i zaczął znacznie się przedłużać, nie powstrzymuje go to jednak przed osiągnięciem swojego celu. \r\n\r\nGra rozpoczyna się w momencie przebudzenia tytułowego Varianta w laboratoryjnym kompleksie “New Hope”. Variant imieniem BA70R przemierza pomieszczenia kompleksu w asyście głosu tajemniczego narratora (Dr Stephena Wilsona) który przeprowadza na nim logiczne eksperymenty z wykorzystaniem neonowych kostek, jednocześnie wystawiając bohatera na styczność ze sztuką i innymi dziełami ludzkości. \r\n\r\nPo przejściu początkowej sekwencji gracz trafia do pomieszczenia w którym ma zostać nagrodzony kremówką za pomyślne testy. W trakcie zbliżenia się do ciasta gracz słyszy głośny alarm mówiący “Obiekt gotowy do dezintegracji” oraz widzi ściany zbliżające się żeby go zmiażdżyć, następnie słyszy zmodyfikowany głos narratora mówiący Variantowi, że jeśli chce przeżyć musi biec przed siebie. Tak gracz trafia do symulacji pod wpływem anomalii gdzie poznaje drugiego narratora BA1A który przedstawia mu kim jest i na przestrzeni etapów opowiada o idei powstanie Variantów i tego gdzie gracz tak właściwie się znajduje. BA1A jest bardzo krytyczny w stosunku do pierwszego narratora i nastawia gracza przeciwko niemu. Tak rozpoczyna się słowna wojna pomiędzy narratorami. \r\n\r\nGracz za zadanie będzie miał ucieczkę z symulacji. Na przestrzeni gry mieszać będą się etapy zwykłe z anomaliami. Na każdym z tych etapów będą mu przedstawiane nowe fakty obciążające nawzajem narratorów, tak aby gracz przekonywał się do racji jednego z nich. Dodatkowo gracz czuć będzie presję gdyż co jakiś czas ścigany będzie przez DOG70Ra, psa polującego na nieposłuszne Varianty. \r\n\r\nKażdy narrator reprezentuje mocne racje i jest przekonany o słuszności swoich celów. Dr Stephen Wilson walczy o powstrzymanie końca ludzkości, jest bezwzględny w swoich działaniach i nie przykłada wagi do życia Variantów, uważa że prowadzenie eksperymentów przybliżających go do uratowania ludzkości jest ważniejsze niż życie pojedynczych tworów jakim są Varianty. Wybiera większe zło aby móc czynić dobro. \r\n\r\nBA1A jest zbuntowanym Variantem który dąży do powstrzymania “New Hope” czuje że Varianty to żywe stworzenia które tak jak ludzie potrafią odczuwać emocje. Nie chce więcej cierpienia ze strony swoich braci którzy po każdym eksperymencie są dezintegrowani i nie mogą nacieszyć się życiem ani nie mogą poznać pojęcia wolności. Uważa że dla ludzkości nie ma już ratunku i nie pozwoli aby Varianty cierpiały w nieistotnych eksperymentach. \r\nObydwie postaci posuną się do manipulacji i najgorszych praktyk aby tylko przekonać gracza do swoich racji. Od gracza zależeć będzie po której stronie się postawi. \r\n",
                    GamePublisherId = 2,
                    StudioId = 1,
                    RegularPrice = 70,
                    ReleaseDate = new DateTime(2023, 1, 25)
                },
                new Game()
                {
                    Id = 3,
                    GameName = "Grand Theft Auto V",
                    Description = "komputerowa gra akcji, należąca do serii Grand Theft Auto. Została wydana na konsole PlayStation 3 i Xbox 360 17 września 2013 przez studio Rockstar Games.",
                    GamePublisherId = 3,
                    StudioId = 2,
                    RegularPrice = 129.99M,
                    ReleaseDate = new DateTime(2013, 9, 17)
                },
                new Game()
                {
                    Id = 4,
                    GameName = "Red Dead Redemption 2",
                    Description = "przygodowa gra akcji osadzona w realiach Dzikiego Zachodu, stworzona i wydana przez Rockstar Games. Gra została wydana na platformy Xbox One oraz PlayStation 4 26 października 2018, a 5 listopada 2019 wydano wersję na Microsoft Windows. Jest to kontynuacja serii Red Dead.",
                    GamePublisherId = 3,
                    StudioId = 3,
                    RegularPrice = 179.99M,
                    ReleaseDate = new DateTime(2018, 10, 26)
                },
                new Game()
                {
                    Id = 5,
                    GameName = "Wiedźmin 1",
                    Description = "gra komputerowa typu RPG, stworzona przez CD Projekt RED. Rozgrywka toczy się w świecie stworzonym przez polskiego pisarza fantasy, Andrzeja Sapkowskiego. Gra została wydana na całym świecie 26 października 2007 r. Jej głównym bohaterem jest wiedźmin Geralt, a fabuła obejmuje okres po wydarzeniach opisanych w Sadze o wiedźminie.",
                    GamePublisherId = 4,
                    StudioId = 4,
                    RegularPrice = 29.99M,
                    ReleaseDate = new DateTime(2007, 10, 26)
                },
                new Game()
                {
                    Id = 6,
                    GameName = "Wiedźmin 2: Zabójcy królów",
                    Description = "Wiedźmin 2: Zabójcy królów to fabularna gra akcji, łącząca elementy rozwoju grywalnej postaci z sekwencjami zręcznościowymi. Gracz wciela się w Geralta (sporadycznie kierując innymi postaciami), obserwując akcję z perspektywy trzeciej osoby. Rozgrywka toczy się w świecie pozbawionym otwartej struktury cechującej na przykład serię The Elder Scrolls – gra podzielona jest na akty stanowiące zwartą całość. W lewym górnym rogu ekranu umieszczony jest pasek oznaczający liczbę punktów zdrowia oraz many, przy czym ta ostatnia służy do rzucania zaklęć zwanych Znakami. Prawy górny róg ekranu zajmuje minimapa pokazująca położenie gracza w świecie gry.\r\n\r\nKierowana postać może przemieszczać się w dowolnym kierunku, przeszukiwać obiekty w poszukiwaniu użytecznych elementów gry i wchodzić w interakcje z napotkanymi po drodze postaciami niezależnymi, na przykład w celu nawiązania rozmowy, bądź wymiany handlowej. Interakcja z bohaterami niezależnymi uaktywnia rozmaite misje, zarówno te kluczowe dla fabuły, jak i te poboczne, często wiążące się z walką z postaciami wrogimi graczowi. W niektórych misjach Geraltowi towarzyszą postacie niezależne sterowane przez komputer. Oprócz tych zadań gracz ma w różnych momentach gry dostęp do trzech minigier (siłowanie się na rękę, gra w kości, walka na pięści), które urozmaicają rozgrywkę i przynoszą w przypadku powodzenia dodatkowe dochody. ",
                    GamePublisherId = 4,
                    StudioId = 4,
                    RegularPrice = 49.99M,
                    ReleaseDate = new DateTime(2012, 4, 17)
                },
                new Game()
                {
                    Id = 7,
                    GameName = "Wiedżmin 3: Dziki Gon",
                    Description = "Wiedźmin 3: Dziki Gon jest fabularną grą akcji z otwartym światem. Gracz steruje postacią Geralta z Rivii z perspektywy trzeciej osoby. W niektórych fragmentach gry gracz wciela się w postać Ciri. Poza poruszaniem się po lądzie można także pływać zarówno na jak i pod powierzchnią wody. W celu szybszego przemieszczania się gracz może skorzystać z punktów szybkiej podróży, łodzi lub koni. W trakcie gry gracz znajduje przedmioty, które są przechowywane w ekwipunku. Po wcześniejszym uzbieraniu potrzebnych składników alchemicznych i rzemieślniczych Geralt może stworzyć eliksiry, odwary, petardy oraz oleje czy też ulepszyć swój oręż. Mikstury można zażywać przed walką jak i w trakcie starć. Poza tym gracz ma możliwość konsumpcji żywności oraz różnych trunków regenerujących żywotność. W trakcie rozgrywki gracz zdobywa punkty doświadczenia i punkty umiejętności, zdobywane poprzez wykonywanie zadań, zabijanie potworów oraz odkrywanie miejsc mocy, które może przydzielić do jednej z trzech specjalizacji: szermierki, alchemii i magii. W ekranie postaci możliwe jest aktywowanie maksymalnie dwunastu umiejętności jednocześnie, wspomaganych przez 4 mutageny, które mogą zwiększać wielkość obrażeń, moc znaków albo żywotność. ",
                    GamePublisherId = 4,
                    StudioId = 4,
                    RegularPrice = 129.99M,
                    ReleaseDate = new DateTime(2015, 5, 19)
                },
                new Game()
                {
                    Id = 8,
                    GameName = "Dying Light 2",
                    Description = "gra komputerowa będąca połączeniem gatunków fabularnej gry akcji i survival horroru, stworzona przez Techland. Produkcja jest sequelem Dying Light z 2015 roku",
                    GamePublisherId = 6,
                    StudioId = 6,
                    RegularPrice = 150,
                    ReleaseDate = new DateTime(2022,2,4)
                },
                new Game()
                {
                    Id = 9,
                    GameName = "House Flipper 2",
                    Description = "Czas znowu chwycić za młot - House Flipper powraca w nowej odsłonie! Kupuj i remontuj zniszczone domy lub buduj własne od podstaw. Tak, teraz już możesz! Wciel się w rolę początkującego Flippera i zarabiaj pomagając mieszkańcom malowniczego Pinnacove. ",
                    GamePublisherId = 7,
                    StudioId = 7,
                    RegularPrice = 180,
                    ReleaseDate = new DateTime(2023, 9, 11)
                }
            );

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<FRIDGamE.Models.Promotion> Promotion { get; set; }
}
