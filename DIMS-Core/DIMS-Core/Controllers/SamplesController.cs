using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models.Samples;
using DIMS_Core.Models.Sample;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIMS_Core.Controllers
{
    [Route("samples")]
    public class SamplesController : Controller
    {
        private readonly ISampleService _sampleService;
        private readonly IMapper _mapper;

        public SamplesController(ISampleService sampleService, IMapper mapper)
        {
            _sampleService = sampleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var searchResult = await _sampleService.Search(null);
            var model = _mapper.Map<IReadOnlyCollection<SampleResponse>>(searchResult);

            return View(model);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var dto = await _sampleService.GetSample(id);
            var model = _mapper.Map<SampleResponse>(dto);

            return View(model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] SampleRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<SampleResponse>(model));
            }

            var dto = _mapper.Map<SampleRequestDto>(model);

            await _sampleService.Create(dto);

            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var dto = await _sampleService.GetSample(id);
            var model = _mapper.Map<SampleResponse>(dto);

            return View(model);
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SampleRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<SampleResponse>(model));
            }

            if (id <= 0)
            {
                ModelState.AddModelError("", "Incorrect identifier.");

                return View(_mapper.Map<SampleResponse>(model));
            }

            var dto = _mapper.Map<SampleRequestDto>(model);

            await _sampleService.Update(id, dto);

            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var dto = await _sampleService.GetSample(id);
            var model = _mapper.Map<SampleResponse>(dto);

            return View(model);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _sampleService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}