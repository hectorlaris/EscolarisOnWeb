﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;


namespace UseCases.CategoriesUseCases
{
	public class DeleteCategoryUseCase : IDeleteCategoryUseCase
	{
		private readonly ICategoryRepository categoryRepository;

		public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		public void Execute(int categoryId)
		{
			categoryRepository.DeleteCategory(categoryId);
		}
	}
}
