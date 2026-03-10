using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string EndPointName = "GetGameById";

List<GameDto> games = [
    new (1, "Elden Ring", "Action RPG", 59.99M, new DateOnly(2022, 2, 25)),
	new (2, "Stardew Valley", "Simulation", 14.99M, new DateOnly(2016, 2, 26)),
	new (3, "The Witcher 3: Wild Hunt", "Action RPG", 39.99M, new DateOnly(2015, 5, 19)),
	new (4, "Hollow Knight", "Metroidvania", 15.99M, new DateOnly(2017, 2, 24)),
	new (5, "Celeste", "Platformer", 19.99M, new DateOnly(2018, 1, 25)),
	new (6, "Minecraft", "Sandbox", 26.95M, new DateOnly(2011, 11, 18)),
	new (7, "God of War", "Action", 49.99M, new DateOnly(2018, 4, 20)),
	new (8, "Super Mario Odyssey", "Platformer", 59.99M, new DateOnly(2017, 10, 27)),
	new (9, "Dark Souls III", "Action RPG", 29.99M, new DateOnly(2016, 3, 24)),
	new (10, "Portal 2", "Puzzle", 9.99M, new DateOnly(2011, 4, 19)),
	new (11, "Half-Life 2", "FPS", 9.99M, new DateOnly(2004, 11, 16)),
	new (12, "The Legend of Zelda: Breath of the Wild", "Action Adventure", 59.99M, new DateOnly(2017, 3, 3)),
	new (13, "Red Dead Redemption 2", "Action Adventure", 59.99M, new DateOnly(2018, 10, 26)),
	new (14, "Disco Elysium", "RPG", 39.99M, new DateOnly(2019, 10, 15)),
	new (15, "Among Us", "Party", 4.99M, new DateOnly(2018, 6, 15)),
	new (16, "DOOM Eternal", "FPS", 39.99M, new DateOnly(2020, 3, 20)),
	new (17, "Hades", "Roguelike", 24.99M, new DateOnly(2020, 9, 17)),
	new (18, "Monster Hunter: World", "Action", 49.99M, new DateOnly(2018, 1, 26)),
	new (19, "Persona 5 Royal", "JRPG", 59.99M, new DateOnly(2019, 3, 31)),
	new (20, "Overwatch", "FPS", 39.99M, new DateOnly(2016, 5, 24)),
	new (21, "The Sims 4", "Simulation", 39.99M, new DateOnly(2014, 9, 2)),
	new (22, "Fallout 4", "RPG", 29.99M, new DateOnly(2015, 11, 10)),
	new (23, "Sekiro: Shadows Die Twice", "Action", 59.99M, new DateOnly(2019, 3, 22)),
	new (24, "Cuphead", "Run and Gun", 19.99M, new DateOnly(2017, 9, 29)),
	new (25, "Metal Gear Solid V: The Phantom Pain", "Stealth", 29.99M, new DateOnly(2015, 9, 1)),
	new (26, "Factorio", "Simulation", 30.00M, new DateOnly(2020, 8, 14)),
	new (27, "Slay the Spire", "Deckbuilder", 24.99M, new DateOnly(2019, 1, 23)),
	new (28, "BioShock Infinite", "FPS", 19.99M, new DateOnly(2013, 3, 26)),
	new (29, "Torchlight II", "Action RPG", 14.99M, new DateOnly(2012, 9, 20)),
	new (30, "Control", "Action Adventure", 29.99M, new DateOnly(2019, 8, 27)),
	new (31, "Baldur's Gate 3", "RPG", 59.99M, new DateOnly(2023, 8, 3)),
	new (32, "Civilization VI", "Strategy", 49.99M, new DateOnly(2016, 10, 21)),
	new (33, "Terraria", "Sandbox", 9.99M, new DateOnly(2011, 5, 16)),
	new (34, "Journey", "Adventure", 14.99M, new DateOnly(2012, 3, 13)),
	new (35, "GTA V", "Action Adventure", 29.99M, new DateOnly(2013, 9, 17)),
	new (36, "Rocket League", "Sports", 19.99M, new DateOnly(2015, 7, 7)),
	new (37, "Plants vs. Zombies", "Tower Defense", 4.99M, new DateOnly(2009, 5, 5)),
	new (38, "Skyrim", "Action RPG", 39.99M, new DateOnly(2011, 11, 11)),
	new (39, "Phasmophobia", "Horror", 13.99M, new DateOnly(2020, 9, 18)),
	new (40, "Mass Effect 2", "RPG", 9.99M, new DateOnly(2010, 1, 26)),
	new (41, "Hand of Fate 2", "Action RPG", 24.99M, new DateOnly(2017, 7, 28)),
	new (42, "Papers, Please", "Simulation", 9.99M, new DateOnly(2013, 8, 8)),
	new (43, "FTL: Faster Than Light", "Strategy", 9.99M, new DateOnly(2012, 9, 14)),
	new (44, "XCOM 2", "Strategy", 39.99M, new DateOnly(2016, 2, 5)),
	new (45, "Ori and the Blind Forest", "Platformer", 19.99M, new DateOnly(2015, 3, 11)),
	new (46, "The Last of Us Part II", "Action Adventure", 59.99M, new DateOnly(2020, 6, 19)),
	new (47, "It Takes Two", "Co-op", 39.99M, new DateOnly(2021, 3, 26)),
	new (48, "Returnal", "Roguelike", 69.99M, new DateOnly(2021, 4, 30)),
	new (49, "Sifu", "Beat 'em up", 39.99M, new DateOnly(2022, 2, 8)),
	new (50, "Braid", "Puzzle Platformer", 9.99M, new DateOnly(2008, 8, 6))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id)=>
    games.Find(game => game.Id == id))
    .WithName(EndPointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame)=>{
    var game = new GameDto(
        Id: games.Count + 1,
        Name: newGame.Name,
        Genre: newGame.Genre,
        Price: newGame.Price,
        releaseDate: newGame.ReleaseDate
    );

    games.Add(game);

    //Calls the GetGameById endpoint to return the newly created game with a 201 status code.
    //new { id = game.Id } is the route values for the GetGameById endpoint, which will be used to generate the URL for the newly created game.
    return Results.CreatedAtRoute(EndPointName, new { id = game.Id }, game);
});

// PUT /games/{id}
app.MapPut("/games/{id}",(int id, UpdateGameDto updatedGame)=> {
    var index = games.FindIndex(game => game.Id == id);

    games[index]  = new GameDto(
        Id: id,
        Name: updatedGame.Name,
        Genre: updatedGame.Genre,
        Price: updatedGame.Price,
        releaseDate: updatedGame.ReleaseDate
    );

    return Results.NoContent();
});

// DELETE /games/{id}
app.MapDelete("/games/{id}", (int id) => {
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
        return Results.NotFound();

    games.RemoveAt(index);

    return Results.NoContent();
});

app.Run();
