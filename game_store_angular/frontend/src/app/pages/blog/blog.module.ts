import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OwlModule } from 'angular-owl-carousel';

import { SharedModule } from '../../shared/shared.module';
import { BlogRoutingModule } from './blog-routing.module';

// pages
import { ClassicPageComponent } from './classic/classic.component';
import { SingleDefaultPageComponent } from './single-default/single-default.component';

// single component
import { BlogSidebarComponent } from './shared/blog-sidebar/blog-sidebar.component';
import { BlogEntryIsotopeComponent } from './shared/blog-entry-isotope/blog-entry-isotope.component';
import { RelatedPostsComponent } from './shared/related-posts/related-posts.component';

@NgModule({
	declarations: [
		ClassicPageComponent,
		SingleDefaultPageComponent,
		BlogSidebarComponent,
		BlogEntryIsotopeComponent,
		RelatedPostsComponent
	],
	imports: [
		CommonModule,
		SharedModule,
		BlogRoutingModule,
		OwlModule
	]
})

export class BlogModule { }
