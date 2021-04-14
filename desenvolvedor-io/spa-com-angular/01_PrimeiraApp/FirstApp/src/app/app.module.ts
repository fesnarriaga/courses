import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modules
import { AppRoutingModule } from './app-routing.module';

// Components
import { AppComponent } from './app.component';
import { ComponentNameComponent } from './folder/component-name/component-name.component';

// Services
import { SomeServiceService } from './some-service.service';

@NgModule({
  declarations: [
    AppComponent,
    ComponentNameComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    SomeServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
