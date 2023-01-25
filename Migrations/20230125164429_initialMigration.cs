using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRIDGamE.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    developer_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisher_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    GamePublisherId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegularPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developers_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_GamePublisherId",
                        column: x => x.GamePublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Customer_AuthorCustomerId",
                        column: x => x.AuthorCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerGame",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    OwnersCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGame", x => new { x.GamesId, x.OwnersCustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerGame_Customer_OwnersCustomerId",
                        column: x => x.OwnersCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameNameId = table.Column<int>(type: "int", nullable: false),
                    RegularPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    EndOfPromotion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartOfPromotion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Games_GameNameId",
                        column: x => x.GameNameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34cb5842-05fe-4502-80ea-acddac81ec1e", "f8f346f5-622c-4474-a4df-bb84a34eac95", "Admin", "ADMIN" },
                    { "a1b6d163-549c-44fc-a0a6-5a15596c0470", "7a1b4bb6-ddd7-4fa2-98bb-324c4b8a8730", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "developer_name", "nip" },
                values: new object[,]
                {
                    { 1, "Yacoper", "4209342137" },
                    { 2, "Rockstar North", "4403144050" },
                    { 3, "Rockstar Games", "4403144051" },
                    { 4, "CD Projekt Red", "9111129970" },
                    { 5, "Ubisoft", "0048997663" },
                    { 6, "Techland", "4925793530" },
                    { 7, "Frozen District", "7792453949" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "nip", "publisher_name" },
                values: new object[,]
                {
                    { 1, "7361066403", "ZSHT" },
                    { 2, "3503493043", "Yacoper INC" },
                    { 3, "2095394934", "Take-Two Interactive" },
                    { 4, "2450923585", "CDPR" },
                    { 5, "2590358583", "Ubisoft" },
                    { 6, "2094672468", "Techland" },
                    { 7, "5213609756", "PlayWay" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "GameName", "GamePublisherId", "RegularPrice", "ReleaseDate", "StudioId" },
                values: new object[,]
                {
                    { 1, " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vehicula ac sem ut semper. Curabitur auctor, nibh eu dictum consequat, sapien tellus condimentum sem, et pulvinar nisl nunc sit amet leo. Nam in velit vitae neque mollis sodales quis at diam. Nunc placerat elit tellus, id iaculis nisl commodo quis. Maecenas ac neque tortor. Phasellus eget nisi vel arcu lobortis tempus at non felis. Nulla finibus magna vel eros pretium, sed eleifend diam porta. Integer pellentesque lacus sollicitudin ligula porta finibus. Nullam ornare et sapien a tincidunt. Nullam quam libero, congue sit amet velit eu, suscipit sagittis neque. Aliquam at luctus sem. Nullam ut feugiat elit, tempor dignissim leo. Maecenas sit amet dui augue. Donec bibendum laoreet turpis, et rhoncus diam iaculis sed. Morbi tincidunt erat at ligula congue, ut vestibulum arcu vehicula. Phasellus vitae vestibulum mi.\r\n\r\nSed tristique lectus non nibh vehicula, vel tempor augue ornare. Fusce at lacus vitae libero congue auctor ut in massa. Nunc id neque magna. Integer nec tellus et ante tempus laoreet sit amet vitae leo. Curabitur ut lacus ut lorem feugiat fringilla. Pellentesque ac ornare neque, ut tincidunt orci. Cras tristique scelerisque vulputate. In pulvinar porta odio, non scelerisque elit sagittis non. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur laoreet fringilla malesuada. Cras cursus arcu felis, a scelerisque urna ullamcorper quis. Praesent facilisis, nulla a elementum fermentum, dui nisl mollis ipsum, auctor maximus ligula ipsum et justo. Morbi ac ex a nulla fermentum sollicitudin. Aenean tempus eros venenatis semper rutrum. In quis tempor nunc, ac efficitur enim. Proin malesuada ex eget elit venenatis, ut suscipit dui auctor. ", "Lorem Ipsum", 1, 0m, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "“New Hope” to nazwa projektu opracowanego przez Dr Stephena Wilsona, genialnego naukowca który w celu uratowania ludzkości przed zagładą, postanawia stworzyć symulację. Celem eksperymentu jest utworzenie rewolucji w łączeniu ludzi z maszynami aby uratować ludzkość. Tak właśnie powstały Varianty, twory które odporne byłyby na jakikolwiek rodzaj chorób. Niestety eksperyment nie poszedł zgodnie z planem Doktora i zaczął znacznie się przedłużać, nie powstrzymuje go to jednak przed osiągnięciem swojego celu. \r\n\r\nGra rozpoczyna się w momencie przebudzenia tytułowego Varianta w laboratoryjnym kompleksie “New Hope”. Variant imieniem BA70R przemierza pomieszczenia kompleksu w asyście głosu tajemniczego narratora (Dr Stephena Wilsona) który przeprowadza na nim logiczne eksperymenty z wykorzystaniem neonowych kostek, jednocześnie wystawiając bohatera na styczność ze sztuką i innymi dziełami ludzkości. \r\n\r\nPo przejściu początkowej sekwencji gracz trafia do pomieszczenia w którym ma zostać nagrodzony kremówką za pomyślne testy. W trakcie zbliżenia się do ciasta gracz słyszy głośny alarm mówiący “Obiekt gotowy do dezintegracji” oraz widzi ściany zbliżające się żeby go zmiażdżyć, następnie słyszy zmodyfikowany głos narratora mówiący Variantowi, że jeśli chce przeżyć musi biec przed siebie. Tak gracz trafia do symulacji pod wpływem anomalii gdzie poznaje drugiego narratora BA1A który przedstawia mu kim jest i na przestrzeni etapów opowiada o idei powstanie Variantów i tego gdzie gracz tak właściwie się znajduje. BA1A jest bardzo krytyczny w stosunku do pierwszego narratora i nastawia gracza przeciwko niemu. Tak rozpoczyna się słowna wojna pomiędzy narratorami. \r\n\r\nGracz za zadanie będzie miał ucieczkę z symulacji. Na przestrzeni gry mieszać będą się etapy zwykłe z anomaliami. Na każdym z tych etapów będą mu przedstawiane nowe fakty obciążające nawzajem narratorów, tak aby gracz przekonywał się do racji jednego z nich. Dodatkowo gracz czuć będzie presję gdyż co jakiś czas ścigany będzie przez DOG70Ra, psa polującego na nieposłuszne Varianty. \r\n\r\nKażdy narrator reprezentuje mocne racje i jest przekonany o słuszności swoich celów. Dr Stephen Wilson walczy o powstrzymanie końca ludzkości, jest bezwzględny w swoich działaniach i nie przykłada wagi do życia Variantów, uważa że prowadzenie eksperymentów przybliżających go do uratowania ludzkości jest ważniejsze niż życie pojedynczych tworów jakim są Varianty. Wybiera większe zło aby móc czynić dobro. \r\n\r\nBA1A jest zbuntowanym Variantem który dąży do powstrzymania “New Hope” czuje że Varianty to żywe stworzenia które tak jak ludzie potrafią odczuwać emocje. Nie chce więcej cierpienia ze strony swoich braci którzy po każdym eksperymencie są dezintegrowani i nie mogą nacieszyć się życiem ani nie mogą poznać pojęcia wolności. Uważa że dla ludzkości nie ma już ratunku i nie pozwoli aby Varianty cierpiały w nieistotnych eksperymentach. \r\nObydwie postaci posuną się do manipulacji i najgorszych praktyk aby tylko przekonać gracza do swoich racji. Od gracza zależeć będzie po której stronie się postawi. \r\n", "The Variant", 2, 70m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "komputerowa gra akcji, należąca do serii Grand Theft Auto. Została wydana na konsole PlayStation 3 i Xbox 360 17 września 2013 przez studio Rockstar Games.", "Grand Theft Auto V", 3, 129.99m, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "przygodowa gra akcji osadzona w realiach Dzikiego Zachodu, stworzona i wydana przez Rockstar Games. Gra została wydana na platformy Xbox One oraz PlayStation 4 26 października 2018, a 5 listopada 2019 wydano wersję na Microsoft Windows. Jest to kontynuacja serii Red Dead.", "Red Dead Redemption 2", 3, 179.99m, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, "gra komputerowa typu RPG, stworzona przez CD Projekt RED. Rozgrywka toczy się w świecie stworzonym przez polskiego pisarza fantasy, Andrzeja Sapkowskiego. Gra została wydana na całym świecie 26 października 2007 r. Jej głównym bohaterem jest wiedźmin Geralt, a fabuła obejmuje okres po wydarzeniach opisanych w Sadze o wiedźminie.", "Wiedźmin 1", 4, 29.99m, new DateTime(2007, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, "Wiedźmin 2: Zabójcy królów to fabularna gra akcji, łącząca elementy rozwoju grywalnej postaci z sekwencjami zręcznościowymi. Gracz wciela się w Geralta (sporadycznie kierując innymi postaciami), obserwując akcję z perspektywy trzeciej osoby. Rozgrywka toczy się w świecie pozbawionym otwartej struktury cechującej na przykład serię The Elder Scrolls – gra podzielona jest na akty stanowiące zwartą całość. W lewym górnym rogu ekranu umieszczony jest pasek oznaczający liczbę punktów zdrowia oraz many, przy czym ta ostatnia służy do rzucania zaklęć zwanych Znakami. Prawy górny róg ekranu zajmuje minimapa pokazująca położenie gracza w świecie gry.\r\n\r\nKierowana postać może przemieszczać się w dowolnym kierunku, przeszukiwać obiekty w poszukiwaniu użytecznych elementów gry i wchodzić w interakcje z napotkanymi po drodze postaciami niezależnymi, na przykład w celu nawiązania rozmowy, bądź wymiany handlowej. Interakcja z bohaterami niezależnymi uaktywnia rozmaite misje, zarówno te kluczowe dla fabuły, jak i te poboczne, często wiążące się z walką z postaciami wrogimi graczowi. W niektórych misjach Geraltowi towarzyszą postacie niezależne sterowane przez komputer. Oprócz tych zadań gracz ma w różnych momentach gry dostęp do trzech minigier (siłowanie się na rękę, gra w kości, walka na pięści), które urozmaicają rozgrywkę i przynoszą w przypadku powodzenia dodatkowe dochody. ", "Wiedźmin 2: Zabójcy królów", 4, 49.99m, new DateTime(2012, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, "Wiedźmin 3: Dziki Gon jest fabularną grą akcji z otwartym światem. Gracz steruje postacią Geralta z Rivii z perspektywy trzeciej osoby. W niektórych fragmentach gry gracz wciela się w postać Ciri. Poza poruszaniem się po lądzie można także pływać zarówno na jak i pod powierzchnią wody. W celu szybszego przemieszczania się gracz może skorzystać z punktów szybkiej podróży, łodzi lub koni. W trakcie gry gracz znajduje przedmioty, które są przechowywane w ekwipunku. Po wcześniejszym uzbieraniu potrzebnych składników alchemicznych i rzemieślniczych Geralt może stworzyć eliksiry, odwary, petardy oraz oleje czy też ulepszyć swój oręż. Mikstury można zażywać przed walką jak i w trakcie starć. Poza tym gracz ma możliwość konsumpcji żywności oraz różnych trunków regenerujących żywotność. W trakcie rozgrywki gracz zdobywa punkty doświadczenia i punkty umiejętności, zdobywane poprzez wykonywanie zadań, zabijanie potworów oraz odkrywanie miejsc mocy, które może przydzielić do jednej z trzech specjalizacji: szermierki, alchemii i magii. W ekranie postaci możliwe jest aktywowanie maksymalnie dwunastu umiejętności jednocześnie, wspomaganych przez 4 mutageny, które mogą zwiększać wielkość obrażeń, moc znaków albo żywotność. ", "Wiedżmin 3: Dziki Gon", 4, 129.99m, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, "gra komputerowa będąca połączeniem gatunków fabularnej gry akcji i survival horroru, stworzona przez Techland. Produkcja jest sequelem Dying Light z 2015 roku", "Dying Light 2", 6, 150m, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 9, "Czas znowu chwycić za młot - House Flipper powraca w nowej odsłonie! Kupuj i remontuj zniszczone domy lub buduj własne od podstaw. Tak, teraz już możesz! Wciel się w rolę początkującego Flippera i zarabiaj pomagając mieszkańcom malowniczego Pinnacove. ", "House Flipper 2", 7, 180m, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentityUserId",
                table: "Customer",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGame_OwnersCustomerId",
                table: "CustomerGame",
                column: "OwnersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GamePublisherId",
                table: "Games",
                column: "GamePublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StudioId",
                table: "Games",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorCustomerId",
                table: "News",
                column: "AuthorCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_GameNameId",
                table: "Promotions",
                column: "GameNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerGame");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
