import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OwlModule } from 'angular-owl-carousel';

import { SharedModule } from '../../shared/shared.module';

import { SpecialCollectionComponent } from './special-collection/special-collection.component';
import { RecommendCollectionComponent } from './recommend-collection/recommend-collection.component';
import { IndexComponent } from './index/index.component';
import { BlogCollectionComponent } from './blog-collection/blog-collection.component';
import { NewCollectionComponent } from './new-collection/new-collection.component';

@NgModule({
	declarations: [
		IndexComponent,
		SpecialCollectionComponent,
		RecommendCollectionComponent,
		BlogCollectionComponent,
		NewCollectionComponent
	],

	imports: [
		CommonModule,
		RouterModule,
		NgbModule,
		OwlModule,
		SharedModule
	]
})

export class HomeModule { }
