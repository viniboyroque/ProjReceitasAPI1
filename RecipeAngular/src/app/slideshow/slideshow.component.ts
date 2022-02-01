import { Component, OnInit } from '@angular/core';
import { Recipe } from '../models/Recipe';
import { RecipeService } from '../service/recipe.service';

@Component({
  selector: 'app-slideshow',
  templateUrl: './slideshow.component.html',
  styleUrls: ['./slideshow.component.css']
})
export class SlideshowComponent implements OnInit {

  public recipes: Recipe[] = [];

  constructor(private recipeService: RecipeService) { }

  ngOnInit() {
    this.loadRecipe();
  }
  loadRecipe(){
    this.recipeService.getAll().subscribe(
      (recipes: Recipe[]) => {this.recipes = recipes;},
      (erro: any) => {console.error(erro)}
    );
  }

}
