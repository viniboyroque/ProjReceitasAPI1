import { Photo } from "../Interfaces/Photo";

export class Recipe {
    constructor() {
        this.id = 0;
        this.title = '';
        this.recipeBody = '';
        this.difficulty = '';
        this.category = '';
        this.time = '';
        this.ingredients = [{'name':'', 'quantity':''}];
        this.UserId = 0;
        this.photos= [{'imageUrl': '', 'publicId': ''}];
        
        
    }
    id?: number;
    title: string;
    recipeBody: string;
    difficulty: string;
    category: string;
    time: string;
    ingredients: [{'name': string, 'quantity':string}];
    UserId: number;
    photos: [{'imageUrl': string, 'publicId': string}];
   
}
