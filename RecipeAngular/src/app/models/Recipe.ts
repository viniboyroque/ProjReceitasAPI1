export class Recipe {
    constructor() {
        this.id = 0;
        this.title = '';
        this.recipeBody = '';
        this.difficulty = '';
        this.category = '';
        this.time = '';
        this.ingredientsRecipes = [{'ingredient': {'name':'', 'quantity':''}}];
        
        
    }
    id: number;
    title: string;
    recipeBody: string;
    difficulty: string;
    category: string;
    time: string;
    ingredientsRecipes: [{'ingredient': {'name': string, 'quantity':string}}];
   
}
