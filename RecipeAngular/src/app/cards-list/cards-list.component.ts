import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from '../models/Recipe';
import { RecipeService } from '../service/recipe.service';

@Component({
  selector: 'app-cards-list',
  templateUrl: './cards-list.component.html',
  styleUrls: ['./cards-list.component.css']
})
export class CardsListComponent implements OnInit {


  public cards: Recipe[];
  constructor(private recipeService: RecipeService, private route: ActivatedRoute,) { }

  ngOnInit() {
    this.loadRecipe();
    // this.getRecipe();
  }

//   getRecipe(): void {
//     const id = Number(this.cards);
// //     const id = Number(this.route.paramMap.subscribe((param: ParamMap) => { 
// //       let id = parseInt(param.get('id') || ('')); 
// //       this.recipe.id = id;
// // }));
    
    
//     this.recipeService.getById(id)
//       .subscribe(recipe => this.recipe = recipe);
//   }

  loadRecipe(){
    this.recipeService.getAll().subscribe(
      (cards: Recipe[]) => {this.cards = cards;},
      (erro: any) => {console.error(erro)}
    );
  }

}
