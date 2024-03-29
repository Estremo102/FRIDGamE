﻿// <auto-generated />
using System;
using FRIDGamE.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FRIDGamE.Migrations
{
    [DbContext(typeof(IdentityContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerGame", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnersCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "OwnersCustomerId");

                    b.HasIndex("OwnersCustomerId");

                    b.ToTable("CustomerGame");
                });

            modelBuilder.Entity("FRIDGamE.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerId");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FRIDGamE.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("developer_name");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("nip");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeveloperName = "Yacoper",
                            NIP = "4209342137"
                        },
                        new
                        {
                            Id = 2,
                            DeveloperName = "Rockstar North",
                            NIP = "4403144050"
                        },
                        new
                        {
                            Id = 3,
                            DeveloperName = "Rockstar Games",
                            NIP = "4403144051"
                        },
                        new
                        {
                            Id = 4,
                            DeveloperName = "CD Projekt Red",
                            NIP = "9111129970"
                        },
                        new
                        {
                            Id = 5,
                            DeveloperName = "Ubisoft",
                            NIP = "0048997663"
                        },
                        new
                        {
                            Id = 6,
                            DeveloperName = "Techland",
                            NIP = "4925793530"
                        },
                        new
                        {
                            Id = 7,
                            DeveloperName = "Frozen District",
                            NIP = "7792453949"
                        });
                });

            modelBuilder.Entity("FRIDGamE.Models.FRIDGamEUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FRIDGamE.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GamePublisherId")
                        .HasColumnType("int");

                    b.Property<decimal>("RegularPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamePublisherId");

                    b.HasIndex("StudioId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vehicula ac sem ut semper. Curabitur auctor, nibh eu dictum consequat, sapien tellus condimentum sem, et pulvinar nisl nunc sit amet leo. Nam in velit vitae neque mollis sodales quis at diam. Nunc placerat elit tellus, id iaculis nisl commodo quis. Maecenas ac neque tortor. Phasellus eget nisi vel arcu lobortis tempus at non felis. Nulla finibus magna vel eros pretium, sed eleifend diam porta. Integer pellentesque lacus sollicitudin ligula porta finibus. Nullam ornare et sapien a tincidunt. Nullam quam libero, congue sit amet velit eu, suscipit sagittis neque. Aliquam at luctus sem. Nullam ut feugiat elit, tempor dignissim leo. Maecenas sit amet dui augue. Donec bibendum laoreet turpis, et rhoncus diam iaculis sed. Morbi tincidunt erat at ligula congue, ut vestibulum arcu vehicula. Phasellus vitae vestibulum mi.\r\n\r\nSed tristique lectus non nibh vehicula, vel tempor augue ornare. Fusce at lacus vitae libero congue auctor ut in massa. Nunc id neque magna. Integer nec tellus et ante tempus laoreet sit amet vitae leo. Curabitur ut lacus ut lorem feugiat fringilla. Pellentesque ac ornare neque, ut tincidunt orci. Cras tristique scelerisque vulputate. In pulvinar porta odio, non scelerisque elit sagittis non. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur laoreet fringilla malesuada. Cras cursus arcu felis, a scelerisque urna ullamcorper quis. Praesent facilisis, nulla a elementum fermentum, dui nisl mollis ipsum, auctor maximus ligula ipsum et justo. Morbi ac ex a nulla fermentum sollicitudin. Aenean tempus eros venenatis semper rutrum. In quis tempor nunc, ac efficitur enim. Proin malesuada ex eget elit venenatis, ut suscipit dui auctor. ",
                            GameName = "Lorem Ipsum",
                            GamePublisherId = 1,
                            RegularPrice = 0m,
                            ReleaseDate = new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "“New Hope” to nazwa projektu opracowanego przez Dr Stephena Wilsona, genialnego naukowca który w celu uratowania ludzkości przed zagładą, postanawia stworzyć symulację. Celem eksperymentu jest utworzenie rewolucji w łączeniu ludzi z maszynami aby uratować ludzkość. Tak właśnie powstały Varianty, twory które odporne byłyby na jakikolwiek rodzaj chorób. Niestety eksperyment nie poszedł zgodnie z planem Doktora i zaczął znacznie się przedłużać, nie powstrzymuje go to jednak przed osiągnięciem swojego celu. \r\n\r\nGra rozpoczyna się w momencie przebudzenia tytułowego Varianta w laboratoryjnym kompleksie “New Hope”. Variant imieniem BA70R przemierza pomieszczenia kompleksu w asyście głosu tajemniczego narratora (Dr Stephena Wilsona) który przeprowadza na nim logiczne eksperymenty z wykorzystaniem neonowych kostek, jednocześnie wystawiając bohatera na styczność ze sztuką i innymi dziełami ludzkości. \r\n\r\nPo przejściu początkowej sekwencji gracz trafia do pomieszczenia w którym ma zostać nagrodzony kremówką za pomyślne testy. W trakcie zbliżenia się do ciasta gracz słyszy głośny alarm mówiący “Obiekt gotowy do dezintegracji” oraz widzi ściany zbliżające się żeby go zmiażdżyć, następnie słyszy zmodyfikowany głos narratora mówiący Variantowi, że jeśli chce przeżyć musi biec przed siebie. Tak gracz trafia do symulacji pod wpływem anomalii gdzie poznaje drugiego narratora BA1A który przedstawia mu kim jest i na przestrzeni etapów opowiada o idei powstanie Variantów i tego gdzie gracz tak właściwie się znajduje. BA1A jest bardzo krytyczny w stosunku do pierwszego narratora i nastawia gracza przeciwko niemu. Tak rozpoczyna się słowna wojna pomiędzy narratorami. \r\n\r\nGracz za zadanie będzie miał ucieczkę z symulacji. Na przestrzeni gry mieszać będą się etapy zwykłe z anomaliami. Na każdym z tych etapów będą mu przedstawiane nowe fakty obciążające nawzajem narratorów, tak aby gracz przekonywał się do racji jednego z nich. Dodatkowo gracz czuć będzie presję gdyż co jakiś czas ścigany będzie przez DOG70Ra, psa polującego na nieposłuszne Varianty. \r\n\r\nKażdy narrator reprezentuje mocne racje i jest przekonany o słuszności swoich celów. Dr Stephen Wilson walczy o powstrzymanie końca ludzkości, jest bezwzględny w swoich działaniach i nie przykłada wagi do życia Variantów, uważa że prowadzenie eksperymentów przybliżających go do uratowania ludzkości jest ważniejsze niż życie pojedynczych tworów jakim są Varianty. Wybiera większe zło aby móc czynić dobro. \r\n\r\nBA1A jest zbuntowanym Variantem który dąży do powstrzymania “New Hope” czuje że Varianty to żywe stworzenia które tak jak ludzie potrafią odczuwać emocje. Nie chce więcej cierpienia ze strony swoich braci którzy po każdym eksperymencie są dezintegrowani i nie mogą nacieszyć się życiem ani nie mogą poznać pojęcia wolności. Uważa że dla ludzkości nie ma już ratunku i nie pozwoli aby Varianty cierpiały w nieistotnych eksperymentach. \r\nObydwie postaci posuną się do manipulacji i najgorszych praktyk aby tylko przekonać gracza do swoich racji. Od gracza zależeć będzie po której stronie się postawi. \r\n",
                            GameName = "The Variant",
                            GamePublisherId = 2,
                            RegularPrice = 70m,
                            ReleaseDate = new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "komputerowa gra akcji, należąca do serii Grand Theft Auto. Została wydana na konsole PlayStation 3 i Xbox 360 17 września 2013 przez studio Rockstar Games.",
                            GameName = "Grand Theft Auto V",
                            GamePublisherId = 3,
                            RegularPrice = 129.99m,
                            ReleaseDate = new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "przygodowa gra akcji osadzona w realiach Dzikiego Zachodu, stworzona i wydana przez Rockstar Games. Gra została wydana na platformy Xbox One oraz PlayStation 4 26 października 2018, a 5 listopada 2019 wydano wersję na Microsoft Windows. Jest to kontynuacja serii Red Dead.",
                            GameName = "Red Dead Redemption 2",
                            GamePublisherId = 3,
                            RegularPrice = 179.99m,
                            ReleaseDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "gra komputerowa typu RPG, stworzona przez CD Projekt RED. Rozgrywka toczy się w świecie stworzonym przez polskiego pisarza fantasy, Andrzeja Sapkowskiego. Gra została wydana na całym świecie 26 października 2007 r. Jej głównym bohaterem jest wiedźmin Geralt, a fabuła obejmuje okres po wydarzeniach opisanych w Sadze o wiedźminie.",
                            GameName = "Wiedźmin 1",
                            GamePublisherId = 4,
                            RegularPrice = 29.99m,
                            ReleaseDate = new DateTime(2007, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 4
                        },
                        new
                        {
                            Id = 6,
                            Description = "Wiedźmin 2: Zabójcy królów to fabularna gra akcji, łącząca elementy rozwoju grywalnej postaci z sekwencjami zręcznościowymi. Gracz wciela się w Geralta (sporadycznie kierując innymi postaciami), obserwując akcję z perspektywy trzeciej osoby. Rozgrywka toczy się w świecie pozbawionym otwartej struktury cechującej na przykład serię The Elder Scrolls – gra podzielona jest na akty stanowiące zwartą całość. W lewym górnym rogu ekranu umieszczony jest pasek oznaczający liczbę punktów zdrowia oraz many, przy czym ta ostatnia służy do rzucania zaklęć zwanych Znakami. Prawy górny róg ekranu zajmuje minimapa pokazująca położenie gracza w świecie gry.\r\n\r\nKierowana postać może przemieszczać się w dowolnym kierunku, przeszukiwać obiekty w poszukiwaniu użytecznych elementów gry i wchodzić w interakcje z napotkanymi po drodze postaciami niezależnymi, na przykład w celu nawiązania rozmowy, bądź wymiany handlowej. Interakcja z bohaterami niezależnymi uaktywnia rozmaite misje, zarówno te kluczowe dla fabuły, jak i te poboczne, często wiążące się z walką z postaciami wrogimi graczowi. W niektórych misjach Geraltowi towarzyszą postacie niezależne sterowane przez komputer. Oprócz tych zadań gracz ma w różnych momentach gry dostęp do trzech minigier (siłowanie się na rękę, gra w kości, walka na pięści), które urozmaicają rozgrywkę i przynoszą w przypadku powodzenia dodatkowe dochody. ",
                            GameName = "Wiedźmin 2: Zabójcy królów",
                            GamePublisherId = 4,
                            RegularPrice = 49.99m,
                            ReleaseDate = new DateTime(2012, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 4
                        },
                        new
                        {
                            Id = 7,
                            Description = "Wiedźmin 3: Dziki Gon jest fabularną grą akcji z otwartym światem. Gracz steruje postacią Geralta z Rivii z perspektywy trzeciej osoby. W niektórych fragmentach gry gracz wciela się w postać Ciri. Poza poruszaniem się po lądzie można także pływać zarówno na jak i pod powierzchnią wody. W celu szybszego przemieszczania się gracz może skorzystać z punktów szybkiej podróży, łodzi lub koni. W trakcie gry gracz znajduje przedmioty, które są przechowywane w ekwipunku. Po wcześniejszym uzbieraniu potrzebnych składników alchemicznych i rzemieślniczych Geralt może stworzyć eliksiry, odwary, petardy oraz oleje czy też ulepszyć swój oręż. Mikstury można zażywać przed walką jak i w trakcie starć. Poza tym gracz ma możliwość konsumpcji żywności oraz różnych trunków regenerujących żywotność. W trakcie rozgrywki gracz zdobywa punkty doświadczenia i punkty umiejętności, zdobywane poprzez wykonywanie zadań, zabijanie potworów oraz odkrywanie miejsc mocy, które może przydzielić do jednej z trzech specjalizacji: szermierki, alchemii i magii. W ekranie postaci możliwe jest aktywowanie maksymalnie dwunastu umiejętności jednocześnie, wspomaganych przez 4 mutageny, które mogą zwiększać wielkość obrażeń, moc znaków albo żywotność. ",
                            GameName = "Wiedżmin 3: Dziki Gon",
                            GamePublisherId = 4,
                            RegularPrice = 129.99m,
                            ReleaseDate = new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 4
                        },
                        new
                        {
                            Id = 8,
                            Description = "gra komputerowa będąca połączeniem gatunków fabularnej gry akcji i survival horroru, stworzona przez Techland. Produkcja jest sequelem Dying Light z 2015 roku",
                            GameName = "Dying Light 2",
                            GamePublisherId = 6,
                            RegularPrice = 150m,
                            ReleaseDate = new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 6
                        },
                        new
                        {
                            Id = 9,
                            Description = "Czas znowu chwycić za młot - House Flipper powraca w nowej odsłonie! Kupuj i remontuj zniszczone domy lub buduj własne od podstaw. Tak, teraz już możesz! Wciel się w rolę początkującego Flippera i zarabiaj pomagając mieszkańcom malowniczego Pinnacove. ",
                            GameName = "House Flipper 2",
                            GamePublisherId = 7,
                            RegularPrice = 180m,
                            ReleaseDate = new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudioId = 7
                        });
                });

            modelBuilder.Entity("FRIDGamE.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("AuthorCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Headline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorCustomerId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("FRIDGamE.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndOfPromotion")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameNameId")
                        .HasColumnType("int");

                    b.Property<decimal>("RegularPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("StartOfPromotion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameNameId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("FRIDGamE.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("nip");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("publisher_name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NIP = "7361066403",
                            PublisherName = "ZSHT"
                        },
                        new
                        {
                            Id = 2,
                            NIP = "3503493043",
                            PublisherName = "Yacoper INC"
                        },
                        new
                        {
                            Id = 3,
                            NIP = "2095394934",
                            PublisherName = "Take-Two Interactive"
                        },
                        new
                        {
                            Id = 4,
                            NIP = "2450923585",
                            PublisherName = "CDPR"
                        },
                        new
                        {
                            Id = 5,
                            NIP = "2590358583",
                            PublisherName = "Ubisoft"
                        },
                        new
                        {
                            Id = 6,
                            NIP = "2094672468",
                            PublisherName = "Techland"
                        },
                        new
                        {
                            Id = 7,
                            NIP = "5213609756",
                            PublisherName = "PlayWay"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "44a0b51b-c3f6-492b-9a10-d701f8f2f77f",
                            ConcurrencyStamp = "750e2fde-d66d-4bed-961c-d5ba93786bdf",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2696ba93-ec93-4530-9675-9bcf60065575",
                            ConcurrencyStamp = "c5a961b5-fa90-4e2a-a7da-c56b6d40cad6",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CustomerGame", b =>
                {
                    b.HasOne("FRIDGamE.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FRIDGamE.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("OwnersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FRIDGamE.Models.Customer", b =>
                {
                    b.HasOne("FRIDGamE.Models.FRIDGamEUser", "IdentityUser")
                        .WithOne("customer")
                        .HasForeignKey("FRIDGamE.Models.Customer", "IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("FRIDGamE.Models.Game", b =>
                {
                    b.HasOne("FRIDGamE.Models.Publisher", "GamePublisher")
                        .WithMany("games")
                        .HasForeignKey("GamePublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FRIDGamE.Models.Developer", "Studio")
                        .WithMany("games")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePublisher");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("FRIDGamE.Models.News", b =>
                {
                    b.HasOne("FRIDGamE.Models.Customer", "Author")
                        .WithMany("News")
                        .HasForeignKey("AuthorCustomerId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FRIDGamE.Models.Promotion", b =>
                {
                    b.HasOne("FRIDGamE.Models.Game", "GameName")
                        .WithMany()
                        .HasForeignKey("GameNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameName");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FRIDGamE.Models.FRIDGamEUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FRIDGamE.Models.FRIDGamEUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FRIDGamE.Models.FRIDGamEUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FRIDGamE.Models.FRIDGamEUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FRIDGamE.Models.Customer", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("FRIDGamE.Models.Developer", b =>
                {
                    b.Navigation("games");
                });

            modelBuilder.Entity("FRIDGamE.Models.FRIDGamEUser", b =>
                {
                    b.Navigation("customer");
                });

            modelBuilder.Entity("FRIDGamE.Models.Publisher", b =>
                {
                    b.Navigation("games");
                });
#pragma warning restore 612, 618
        }
    }
}
