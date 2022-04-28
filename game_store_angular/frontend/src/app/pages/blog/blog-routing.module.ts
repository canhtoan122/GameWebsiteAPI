import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ClassicPageComponent } from './classic/classic.component';
import { SingleDefaultPageComponent } from './single-default/single-default.component';

const routes: Routes = [
	{
		path: '',
		redirectTo: 'classic',
		pathMatch: 'full'
	},
	{
		path: 'classic',
		component: ClassicPageComponent
	},
	{
		path: 'single/default/:slug',
		component: SingleDefaultPageComponent
	}
]

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})

export class BlogRoutingModule { };
