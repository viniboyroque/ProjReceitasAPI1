export class Recipe {
    constructor() {
        this.id = 0;
        this.title = '';
        this.recipeBody = '';
        this.ingredientsRecipes = [{'ingredient': {'name':''}}];
        this.categoriesRecipes = [{'category': {'name': ''}}];
        this.dificultiesRecipes = [{'dificulty': {'name': ''}}];
        
    }
    id: number;
    title: string;
    recipeBody: string;
    ingredientsRecipes: [{'ingredient': {'name': string}}];
    categoriesRecipes: [{'category': {'name': string}}];
    dificultiesRecipes: [{'dificulty': {'name': string}}];
}
