using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeAPI.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"
            DECLARE @UserId as INT
            DECLARE @RecipeId as INT

            --------------------------
            --Create User
            --------------------------
            IF not exists (select Id from Users where Name='Demo')
            insert into Users(Name, Email, Password, PasswordKey)
            select 'Demo',
            'demo@demo.com',
            0x4D5544D09B8319B423F6D4E054360D5289B57A98781A66B276E00C57919FDCD599BF45623D48CC81F535748F560AF0F70C8C7F3B4C3DB672562B5DD0E5E7C297,
            0x44A0BD5BFD689DF399346200A1117C33BEDF5869C17A7CB3DC6D8598A93845DB333B379AA90931D8D4E5F2CC7B1A4A96A7DB71B186DBCDCDC53B0A95440E4EDD7473668627970FBD9BB0BA17530CCAB2D9446A1902BD6AC12FE691FE09DD78A43398B89111056145843060026A414FFA8C5E75B474E187AD753D2872038D9FDD

            SET @UserID = (select id from Users where Name='Demo')

            
            
            --------------------------
            --Seed Recipes
            --------------------------
            IF not exists (select top 1 Title from Recipes where Title='Francesinha')
            insert into Recipes(Title,RecipeBody,Difficulty,Category,Time,UserId)
            select 
            'Francesinha', --Title
            'Para começar esta receita, prepare o molho: descasque a cebola, pique-a grosseiramente, deite para um tacho, junte a margarina e o louro, leve ao lume e deixe cozinhar até ficar douradinha. Adicione a polpa de tomate, o caldo de carne e a cerveja e deixe ferver. Dissolva a farinha maisena num pouco de leite e junte ao tacho, em fio e mexendo sempre. Rectifique o sal, tempere com picante, mexa, junte o brandy e o Vinho do Porto e deixe ferver. Passe pelo passador de rede e leve de novo ao lume brando para aquecer.\r\nCorte as salsichas ao meio, depois novamente ao meio no sentido do comprimento e tempere-as com sal e pimenta. Corte também as linguiças da mesma maneira. Tempere igualmente os bifes com sal e pimenta. Grelhe os bifes, as salsichas e a linguiça a gosto.\r\nTorre ligeiramente as fatias de pão e distribua duas fatias por dois pratos. Cubra com uma fatia de fiambre, junte depois o bife e coloque outra fatia de pão. Adicione então a salsicha e a linguiça, cubra com uma fatia de queijo e o restante pão. Junte então três fatias de queijo por cima de cada conjunto, leve ao forno a 200°C até derreter, retire e sirva quentes regadas com o molho.', --RecipeBody
            'Easy', --Difficulty
            'Dinner', --Category
            '-1h', --Time
            @UserID --UserID
            SET @RecipeId = (select id from Recipes where Title='Francesinha')
            
            --------------------------
            --Seed Ingredients
            --------------------------
            IF not exists (select top 1 Id from Ingredients where Id=1)
            insert into Ingredients(Name,Quantity,RecipeId)
            select 
            'Cebola', --Name
            '4',--Quantity
            @RecipeId --RecipeId

            
            
           


            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DECLARE @UserID as int
            DECLARE @RecipeId as INT
            SET @UserID = (select id from Users where Name='Demo')
            delete from Users where Name='Demo'
            delete from Recipes where UserId=@UserID
            SET @RecipeId = (select id from Recipes where Title='Francesinha')
            delete from Ingredients where RecipeId=@RecipeId
            delete from IngredientsRecipes where IngredientId=1
            
            ");
        }
    }
}
