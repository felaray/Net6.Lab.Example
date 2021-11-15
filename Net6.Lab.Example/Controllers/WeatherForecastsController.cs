﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6.Lab.Example.Data;
using Net6.Lab.Example.Model;

namespace Net6.Lab.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly Net6LabExampleContext _context;

        public WeatherForecastsController(Net6LabExampleContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecast()
        {
            return await _context.WeatherForecast.ToListAsync();
        }

        // GET: api/WeatherForecasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id)
        {
            var weatherForecast = await _context.WeatherForecast.FindAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            var employees = _context.WeatherForecast.ToList();
            foreach (var employee in employees)
            {
                var employeeEntry = _context.Entry(employee);
                //var validFrom = employeeEntry.Property<DateTime>("ValidFrom").CurrentValue;
                //var validTo = employeeEntry.Property<DateTime>("ValidTo").CurrentValue;

                //Console.WriteLine($"  Employee {employee.Name} valid from {validFrom} to {validTo}");
            }


            return weatherForecast;
        }

        // PUT: api/WeatherForecasts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherForecasts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
        {
            _context.WeatherForecast.Add(weatherForecast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Id }, weatherForecast);
        }

        // DELETE: api/WeatherForecasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(int id)
        {
            var weatherForecast = await _context.WeatherForecast.FindAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            _context.WeatherForecast.Remove(weatherForecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastExists(int id)
        {
            return _context.WeatherForecast.Any(e => e.Id == id);
        }
    }
}
