import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { Recipe } from '../models/Recipe';
import { AlertifyService } from '../service/alertify.service';
import { RecipeService } from '../service/recipe.service';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css']
})
export class RecipeCreateComponent implements OnInit {


 
  // @ViewChild('Form') addRecipeForm: NgForm;
  @ViewChild('formTabs') formTabs: TabsetComponent;

  addRecipeForm: FormGroup;

  recipe: Recipe;

  recipeView: Recipe = {
    id: null,
    title: '',
    recipeBody: null,
    difficulty: null,
    category: null,
    time: null,
    ingredientsRecipes: null,
    
  };


  constructor(private fb: FormBuilder, private recipeService: RecipeService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.CreateAddRecipeForm();
  }

  CreateAddRecipeForm() {
    this.addRecipeForm = this.fb.group({
        id: [null],
        title: [null, Validators.required],
        recipeBody: [null, Validators.required],
        difficulty: [null, Validators.required],
        category: [null, Validators.required],
        time: [null, Validators.required],
        ingredientsRecipes: [null]
      });
  }

  

  

  onBack() {
    this.router.navigate(['/']);
  }

  onSubmit() {
    
    console.log(this.addRecipeForm.value);
    if (this.addRecipeForm.valid){
      this.recipeService.post(this.recipeData());
      this.addRecipeForm.reset();
      this.alertify.success('Congrats, recipe subimitted');
      this.router.navigate(['/home'])
    } else {
      this.alertify.error('Kindly provide the required fields');
    }
  }

  

  recipeData(): Recipe{
    return this.recipe = {
    id: this.id.value,
    title: this.title.value,
    recipeBody: this.recipeBody.value,
    difficulty: this.difficulty.value,
    category: this.category.value,
    time: this.time.value,
    ingredientsRecipes: this.ingredientsRecipes.value
    }
  }
  // console.log(this.registerationForm.value);
  //   this.userSubmitted = true;
  //   if (this.registerationForm.valid){
  //     // this.user = Object.assign(this.user, this.registerationForm.value);
  //     this.userService.addUser(this.userData());
  //     this.registerationForm.reset();
  //     this.userSubmitted = false;
  //     this.alertify.success('Congrats, you are registered');
  //   } else {
  //     this.alertify.error('Kindly provide the required fields');
  //   }


  selectTab(tabId: number) {
    this.formTabs.tabs[tabId].active = true;
  }

  // ------------------------------------
  // Getter methods for all form controls
  // ------------------------------------
  get id() {
    return this.addRecipeForm.get('id') as FormControl;
  }
  get title() {
    return this.addRecipeForm.get('title') as FormControl;
  }
  get recipeBody() {
    return this.addRecipeForm.get('recipeBody') as FormControl;
  }
  get difficulty() {
    return this.addRecipeForm.get('difficulty') as FormControl;
  }
  get category() {
    return this.addRecipeForm.get('category') as FormControl;
  }
  get time() {
    return this.addRecipeForm.get('time') as FormControl;
  }
  get ingredientsRecipes() {
    return this.addRecipeForm.get('ingredientsRecipes') as FormControl;
  }
  
  // ------------------------

}

