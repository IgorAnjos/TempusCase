using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessTempus.Interfaces;
using BusinessTempus.Models;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;
using UI.ViewModels.Validations;

namespace UI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;


        public CustomersController(IMapper mapper,
                                   ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        [Route("lista-de-clientes")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAllCustomer()));
        }

        [Route("detalhes-do-clientes/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();

            var cst = await GetCustomer(id);

            if (cst == null) return NotFound();

            return View(cst);
        }

        [Route("novo-cliente")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-cliente")]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(customerViewModel);

                if (await CustomerExists(customerViewModel.CPF))
                {
                    TempData["del"] = "CPF existente!";
                    return View(customerViewModel);
                }

                if (!Validations.VerificationCpf(customerViewModel.CPF))
                {
                    TempData["del"] = "CPF inválido!";
                    return View(customerViewModel);
                }

                customerViewModel.CreatedOn = DateTime.Now;

                await _customerRepository.AddEntity(_mapper.Map<Customer>(customerViewModel));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                throw new Exception($"Error: Erro try ao criar cliente {0}", err);
            }
        }

        [Route("editar-cliente")]
        public async Task<IActionResult> Edit(Guid id)
        {

            if (id == null) return NotFound();

            var cst = await GetCustomer(id);

            if (cst == null) return NotFound();

            string income = cst.FamilyIncome.ToString();
             //string res = orig.Replace("\",\"", ";");
            return View(cst);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-cliente")]
        public async Task<IActionResult> Edit(Guid id, CustomerViewModel customerViewModel)
        {
            try
            {
                if (id != customerViewModel.Id) return NotFound();

                if (!ModelState.IsValid) return View(customerViewModel);

                var cstUpdate = await GetCustomer(id);

                cstUpdate.FullName = customerViewModel.FullName;
                cstUpdate.CPF = customerViewModel.CPF;
                cstUpdate.DateOfBirth = customerViewModel.DateOfBirth;
                cstUpdate.FamilyIncome = customerViewModel.FamilyIncome;

                await _customerRepository.UpdateEntity(_mapper.Map<Customer>(cstUpdate));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                throw new Exception($"Error: Erro try ao editar cliente {0}", err);
            }
        }

        [Route("deletar-cliente")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();

            var cst = await GetCustomer(id);

            if (cst == null) return NotFound();

            return View(cst);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar-cliente")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var cst = await GetCustomer(id);

                await _customerRepository.RemoveEntity(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                throw new Exception($"Error: Erro try ao deletar cliente {0}", err);
            }
        }

        private async Task<bool> CustomerExists(string cpf)
        {
            try
            {
                bool result = true;
                var cst = await _customerRepository.GetCustomerByCpf(cpf);

                if (cst == null) result = false;

                return result;
            }
            catch (Exception err)
            {
                throw new Exception($"Error: Erro try ao verificar cliente existente na base {0}", err);
            }
        }

        private async Task<CustomerViewModel> GetCustomer(Guid id)
        {
            try
            {
                return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerById(id));
            }
            catch (Exception err)
            {
                throw new Exception($"Error: {0}", err);
            }
        }
    }
}
