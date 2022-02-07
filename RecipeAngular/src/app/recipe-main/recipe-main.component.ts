import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';
import { RecipeService } from '../service/recipe.service';
import { Recipe } from '../models/Recipe';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-recipe-main',
  templateUrl: './recipe-main.component.html',
  styleUrls: ['./recipe-main.component.css'],
})
export class RecipeMainComponent implements OnInit, OnDestroy {

  recipe: Recipe = new Recipe();

  idSubscription: Subscription;
  recipeServiceSubscription: Subscription;
  
  constructor(
    private route: ActivatedRoute,
    private recipeService: RecipeService,
    private location: Location
  ) {}

  ngOnInit() {
    this.idSubscription = this.route.paramMap.subscribe((param: ParamMap) => {
      let id = parseInt(param.get('id') || '');
      this.recipeServiceSubscription = this.recipeService
        .getById(id)
        .subscribe((recipe) => (this.recipe = recipe));
        console.log(this.recipe);
    });
  }

  ngOnDestroy(): void {
    this.recipeServiceSubscription.unsubscribe();
    this.idSubscription.unsubscribe();
  }

 
}
