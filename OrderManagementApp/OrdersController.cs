using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baithi.Data;
using baithi.Models;

namespace baithi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private const int PageSize = 10;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var query = _context.Orders.Include(o => o.Product).AsQueryable();

            // Search theo OrderNumber hoặc CustomerName
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(o => o.OrderNumber.Contains(searchString) ||
                                         o.CustomerName.Contains(searchString));
            }

            // Tổng số bản ghi
            int totalRecords = await query.CountAsync();

            // Phân trang
            var orders = await query
                .OrderBy(o => o.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            ViewBag.TotalRecords = totalRecords;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
            ViewBag.SearchString = searchString;

            return View(orders);
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders.Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id) return NotFound();

            // Lấy order gốc từ DB
            var existingOrder = await _context.Orders.Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
            if (existingOrder == null) return NotFound();

            // Không cho phép sửa OrderNumber và ProductId
            order.OrderNumber = existingOrder.OrderNumber;
            order.ProductId = existingOrder.ProductId;

            // Validate logic giống Create
            if (_context.Orders.Any(o => o.CustomerEmail == order.CustomerEmail && o.Id != id))
            {
                ModelState.AddModelError("CustomerEmail", "Customer Email must be unique");
            }

            if (existingOrder.Product == null)
            {
                ModelState.AddModelError("ProductId", "Product not found");
            }
            else if (order.Quantity > existingOrder.Product.StockQuantity)
            {
                ModelState.AddModelError("Quantity", "Quantity cannot exceed product stock quantity");
            }

            if (order.OrderDate > DateTime.Now)
            {
                ModelState.AddModelError("OrderDate", "Order Date cannot be in the future");
            }

            if (order.DeliveryDate.HasValue && order.DeliveryDate < order.OrderDate)
            {
                ModelState.AddModelError("DeliveryDate", "Delivery Date must be greater than or equal to Order Date");
            }

            if (ModelState.IsValid)
            {
                // Cập nhật các trường cho phép
                existingOrder.CustomerName = order.CustomerName;
                existingOrder.CustomerEmail = order.CustomerEmail;
                existingOrder.Quantity = order.Quantity;
                existingOrder.DeliveryDate = order.DeliveryDate;
                existingOrder.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Order updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null) return NotFound();

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Order deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting order: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            // Kiểm tra OrderNumber duy nhất
            if (_context.Orders.Any(o => o.OrderNumber == order.OrderNumber))
            {
                ModelState.AddModelError("OrderNumber", "Order Number must be unique");
            }

            // Kiểm tra CustomerEmail duy nhất
            if (_context.Orders.Any(o => o.CustomerEmail == order.CustomerEmail))
            {
                ModelState.AddModelError("CustomerEmail", "Customer Email must be unique");
            }

            // Kiểm tra Product tồn tại
            var product = await _context.Products.FindAsync(order.ProductId);
            if (product == null)
            {
                ModelState.AddModelError("ProductId", "Selected product does not exist");
            }
            else if (order.Quantity > product.StockQuantity)
            {
                ModelState.AddModelError("Quantity", "Quantity cannot exceed product stock quantity");
            }

            // Kiểm tra OrderDate không lớn hơn ngày hiện tại
            if (order.OrderDate > DateTime.Now)
            {
                ModelState.AddModelError("OrderDate", "Order Date cannot be in the future");
            }

            // Kiểm tra DeliveryDate >= OrderDate
            if (order.DeliveryDate.HasValue && order.DeliveryDate < order.OrderDate)
            {
                ModelState.AddModelError("DeliveryDate", "Delivery Date must be greater than or equal to Order Date");
            }

            if (ModelState.IsValid)
            {
                order.CreatedAt = DateTime.Now;
                order.UpdatedAt = DateTime.Now;

                _context.Add(order);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Order created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }
    }
}