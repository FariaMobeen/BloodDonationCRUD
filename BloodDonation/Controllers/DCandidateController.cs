using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodDonation.Models;

namespace BloodDonation.Controllers
{
    // The controller is for a REST API that manages DCandidate entities in the DonationDBContext (the database context).
    // It is a part of an ASP.NET Core Web API application to handle CRUD (Create, Read, Update, Delete) operations.

    // The controller is decorated with the [Route("api/[controller]")] attribute.
    // This means the API will be accessible at the endpoint "/api/DCandidate".
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        // Private readonly field to store the DonationDBContext instance that will allow interaction with the database.
        private readonly DonationDBContext _context;

        // Constructor that accepts the DonationDBContext instance via dependency injection.
        // This instance is used throughout the controller to interact with the database.
        public DCandidateController(DonationDBContext context)
        {
            _context = context;  // Assigning the injected context to the private field.
        }

        // GET: api/DCandidate
        // This action listens for HTTP GET requests at the "/api/DCandidate" endpoint.
        // It returns a list of all DCandidate records from the database.
    //     	1.	The method is marked with async, which means this method will contain an asynchronous operation.
	// 2.	The return type of the method is Task<ActionResult<IEnumerable<DCandidate>>>:
	// •	Task indicates the method will return a task that will eventually complete.
	// •	ActionResult<IEnumerable<DCandidate>> indicates the type of result the task will return once it’s completed (in this case, an HTTP response containing a list of DCandidate objects).
	// 3.	await _context.DCandidates.ToListAsync();:
	// •	ToListAsync() is an asynchronous method provided by Entity Framework Core that retrieves the list of DCandidate records from the database without blocking the current thread.
	// •	The await keyword is used here to “pause” the method’s execution until the database query is completed. During this time, the HTTP request thread is free to handle other incoming requests, improving the app’s responsiveness.
	// 4.	Once the database operation completes, the result is returned as an ActionResult, containing the list of DCandidate objects.

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDCandidates()
        {
            // Retrieves all DCandidate records from the database asynchronously and returns them as an ActionResult.
            return await _context.DCandidates.ToListAsync();
        }

        // GET: api/DCandidate/5
        // This action listens for GET requests at the "/api/DCandidate/{id}" endpoint.
        // It returns a specific DCandidate by its ID (provided in the URL).
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
            // Finds a DCandidate record by ID asynchronously.
            var dCandidate = await _context.DCandidates.FindAsync(id);

            // If the DCandidate is not found, return a 404 Not Found response.
            if (dCandidate == null)
            {
                return NotFound();
            }

            // Returns the found DCandidate.
            return dCandidate;
        }

        // PUT: api/DCandidate/5
        // This action listens for HTTP PUT requests at "/api/DCandidate/{id}" and is used to update an existing DCandidate.
        // The {id} from the URL is the ID of the record to update, and the request body contains the updated DCandidate object.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DCandidate dCandidate)
        {
            // Set the DCandidate's ID to match the ID from the URL.
            dCandidate.id = id;

            // Mark the DCandidate as modified so that it will be updated in the database.
            _context.Entry(dCandidate).State = EntityState.Modified;

            try
            {
                // Save the changes to the database asynchronously.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If the DCandidate doesn't exist (e.g., someone deleted it before this update), return a 404 Not Found response.
                if (!DCandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // If another error occurs, rethrow the exception.
                    throw;
                }
            }

            // Returns a 204 No Content response, indicating that the update was successful but there is no content to return.
            return NoContent();
        }

        // POST: api/DCandidate
        // This action listens for HTTP POST requests at "/api/DCandidate" and is used to create a new DCandidate.
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dCandidate)
        {
            // Add the new DCandidate to the database context.
            _context.DCandidates.Add(dCandidate);

            // Save the changes to the database asynchronously.
            await _context.SaveChangesAsync();

            // Return a 201 Created response with the URL of the newly created DCandidate and the DCandidate object.
            return CreatedAtAction("GetDCandidate", new { id = dCandidate.id }, dCandidate);
        }

        // DELETE: api/DCandidate/5
        // This action listens for HTTP DELETE requests at "/api/DCandidate/{id}" and is used to delete a DCandidate by its ID.
        [HttpDelete("{id}")]
        public async Task<ActionResult<DCandidate>> DeleteDCandidate(int id)
        {
            // Find the DCandidate to delete by its ID.
            var dCandidate = await _context.DCandidates.FindAsync(id);

            // If the DCandidate is not found, return a 404 Not Found response.
            if (dCandidate == null)
            {
                return NotFound();
            }

            // Remove the DCandidate from the database context.
            _context.DCandidates.Remove(dCandidate);

            // Save the changes to the database asynchronously.
            await _context.SaveChangesAsync();

            // Return the deleted DCandidate object.
            return dCandidate;
        }

        // Helper method to check if a DCandidate exists in the database by its ID.
        private bool DCandidateExists(int id)
        {
            // Returns true if a DCandidate with the given ID exists in the database.
            return _context.DCandidates.Any(e => e.id == id);
        }
    }
}