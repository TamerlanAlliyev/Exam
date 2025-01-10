const rowsPerPage = 10;
let currentPage = 1;

const tableBody = document.getElementById("table-body");
const searchInput = document.getElementById("search");
const rows = Array.from(tableBody.querySelectorAll("tr"));
const prevBtn = document.getElementById("prev-btn");
const nextBtn = document.getElementById("next-btn");
const pageNumbers = document.getElementById("page-numbers");

let filteredRows = rows;


function renderTable() {
  const start = (currentPage - 1) * rowsPerPage;
  const end = start + rowsPerPage;


  rows.forEach((row) => (row.style.display = "none"));

  filteredRows.slice(start, end).forEach((row) => {
    row.style.display = "";
  });

  prevBtn.disabled = currentPage === 1;
  nextBtn.disabled = currentPage === Math.ceil(filteredRows.length / rowsPerPage);

  renderPageNumbers();
}

function renderPageNumbers() {
  pageNumbers.innerHTML = "";
  const totalPages = Math.ceil(filteredRows.length / rowsPerPage);

  for (let i = 1; i <= totalPages; i++) {
    const span = document.createElement("span");
    span.textContent = i;
    span.className = i === currentPage ? "active" : "";
    span.style.cursor = "pointer";

    span.addEventListener("click", () => {
      currentPage = i;
      renderTable();
    });

    pageNumbers.appendChild(span);
  }
}

searchInput.addEventListener("input", () => {
  const searchValue = searchInput.value.toLowerCase();

  filteredRows = rows.filter((row) => {
    return Array.from(row.cells).some((cell) => {
      return cell.textContent.toLowerCase().includes(searchValue);
    });
  });

  currentPage = 1;
  renderTable();
});

prevBtn.addEventListener("click", () => {
  if (currentPage > 1) {
    currentPage--;
    renderTable();
  }
});

nextBtn.addEventListener("click", () => {
  if (currentPage < Math.ceil(filteredRows.length / rowsPerPage)) {
    currentPage++;
    renderTable();
  }
});

renderTable();
