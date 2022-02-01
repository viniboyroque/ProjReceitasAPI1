import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { Recipe } from '../models/Recipe';
import { RecipeService } from '../service/recipe.service';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css']
})
export class RecipeCreateComponent implements OnInit {


  // public recipeForm: FormGroup;
  // // public modo!: string;

  // // public modo!: string;
  // public recipe: Recipe[];
  
  // constructor(private fb: FormBuilder,  private recipeService: RecipeService) { 
  //   this.createForm();
  // }

  // ngOnInit() {
  // }
  // createForm() {
  //   this.recipeForm = this.fb.group({
  //     id: [''],
  //     title: ['', Validators.required],
  //     recipeBody: ['', Validators.required]
  //   });
  // }
  // saveRecipe(recipe: Recipe){
  //   // ? this.modo = 'post' : this.modo = 'put';
  //   if  (recipe.id = 0) 
  //   {
  //     this.recipeService.post(recipe).subscribe(
  //       (retorno: any) => {
  //         console.log(retorno);
  //       },
  //       (erro: any) => {
  //         console.log(erro);
  //       }
  //     );
  //   } else 
  //   {
  //     this.recipeService.put(recipe).subscribe(
  //       (retorno: any) => {
  //         console.log(retorno);
  //       },
  //       (erro: any) => {
  //         console.log(erro);
  //       }
  //     );
  //   }
    
  // }
  // deleteRecipe(id: number){
  //   this.recipeService.delete(id).subscribe(
  //     (model: any) => {
  //       console.log(model);
  //     },
  //     (erro: any) => {
  //       console.error(erro);
  //     }
  //   )
  // }
  
  // recipeSubmit(){
  //   console.log(this.recipeForm.value);
  //   this.saveRecipe(this.recipeForm.value);
  // }

  // // ------------------------------------
  // // Getter methods for all form controls
  // // ------------------------------------
  // get userName() {
  //   return this.recipeForm.get('id') as FormControl;
  // }
  // get id() {
  //   return this.recipeForm.get('title') as FormControl;
  // }
  // get email() {
  //   return this.recipeForm.get('recipeBody') as FormControl;
  // }
  @ViewChild('Form') addRecipeForm: NgForm;
  @ViewChild('formTabs') formTabs: TabsetComponent;

  

  recipeView: Recipe = {
    id: null,
    title: '',
    recipeBody: null,
    ingredientsRecipes: null,
    categoriesRecipes: null,
    dificultiesRecipes: [{'dificulty': {'name': ''}}]
  };


  constructor(private router: Router) { }

  ngOnInit() {
  }

  onBack() {
    this.router.navigate(['/']);
  }

  onSubmit() {
    console.log('Congrats, form Submitted');
    console.log(this.addRecipeForm);
  }

  selectTab(tabId: number) {
    this.formTabs.tabs[tabId].active = true;
  }

}

