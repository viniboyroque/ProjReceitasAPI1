import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CardsModule, MDBBootstrapModule } from 'angular-bootstrap-md';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { SlideshowComponent } from './slideshow/slideshow.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CardsComponent } from './cards/cards.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HttpClientModule } from '@angular/common/http';
import { RecipeMainComponent } from './recipe-main/recipe-main.component';
import { RecipeCreateComponent } from './recipe-create/recipe-create.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RecipeService } from './service/recipe.service';
import { UserService } from './service/user.service';
import { AlertifyService } from './service/alertify.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { CardsListComponent } from './cards-list/cards-list.component';



@NgModule({
  declarations: [										
    AppComponent,
      NavComponent,
      HomeComponent,
      SlideshowComponent,
      PageNotFoundComponent,
      CardsComponent,
      LoginComponent,
      SignupComponent,
      RecipeMainComponent,
      RecipeCreateComponent,
      CardsListComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CardsModule,
    CarouselModule.forRoot(),
    MDBBootstrapModule.forRoot(),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot()
  ],
  providers: [RecipeService, UserService, AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
