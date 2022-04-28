import { Component, OnInit, Input } from '@angular/core';

import { specialSlider } from '../data';

@Component({
	selector: 'molla-special-collection',
	templateUrl: './special-collection.component.html',
	styleUrls: ['./special-collection.component.scss']
})

export class SpecialCollectionComponent implements OnInit {

	@Input() products = [];
	@Input() loaded = false;

	specialSlider = specialSlider;
	attrs = ['all', 'new', 'top'];
	titles = { 'all': 'Now Trending', 'new': 'New Releases', 'top': 'Best-Rated' };

	constructor() { }

	ngOnInit(): void {
	}
}
