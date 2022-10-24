import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getStudents, reset } from "../../features/students/studentsSlice";
import { useNavigate } from "react-router-dom";
import dayjs from "dayjs";

import "../../assets/styles/table.css";
import "./styles/students.css";
import "react-pagination-bar/dist/index.css";
import { Button } from "react-bootstrap";

import Select from "react-select";
import { Pagination } from "react-pagination-bar";
import DeleteModal from "../../components/DeleteModalStudent";

const Students = () => {
  const [filter, setFilter] = useState("");
  const [value, setValue] = useState("");
  const [sort, setSort] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [modalShow, setModalShow] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { students } = useSelector((state) => state.students);

  useEffect(() => {
    const data = {
      api: `/api/students?filter=${filter}&value=${value}&sort=${sort}&page=${page}&pageSize=${pageSize}`,
      token: user?.data?.token,
    };
    dispatch(getStudents(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token, sort, value, page]);

  const options = [
    { value: "selection", label: "Selection" },
    { value: "program", label: "Program" },
    { value: "", label: "None" },
  ];

  const studentStatus = {
    0: "InProgram",
    1: "Success",
    2: "Failed",
    3: "Extended",
  };

  return (
    <div>
      <h1>Students</h1>
      <table>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Birth Date</th>
            <th>Status</th>
            <th>Selection</th>
            <th>Program</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {students?.data?.map((student) => {
            return (
              <tr key={student.id}>
                <td data-label="First Name">{student.firstName}</td>
                <td data-label="Last Name">{student.lastName}</td>
                <td data-label="Birth Date">
                  {dayjs(student.birthDate).format("DD/MM/YYYY")}
                </td>
                <td data-label="Status">{studentStatus[student.status]}</td>
                <td data-label="Selection">{student.selection?.title}</td>
                <td data-label="Program">
                  {student.selection?.program?.title}
                </td>
                <td data-label="Actions">
                  <Button
                    variant="outline-success"
                    size="sm"
                    className="table-btn"
                    onClick={() => navigate("/edit")}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="outline-danger"
                    size="sm"
                    className="table-btn"
                    onClick={() => setModalShow(true)}
                  >
                    Delete
                  </Button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
      <div className="filter-order">
        <div className="order-form">
          <label>Order By:</label>
          <Select
            options={options}
            onChange={(choice) => setSort(choice.value)}
          />
        </div>
        <div className="filter-form">
          <div className="filter-field">
            <label>Filter by:</label>
            <Select
              options={options}
              onChange={(choice) => setFilter(choice.value)}
            />
          </div>
          <input
            type="text"
            value={value}
            onChange={(e) => setValue(e.target.value)}
          />
        </div>
      </div>
      <div className="pagination">
        <Pagination
          totalItems={students?.count}
          itemsPerPage={pageSize}
          onlyPageNumbers={true}
          onPageChange={(pageNumber) => setPage(pageNumber)}
        />
      </div>
      <div className="students-btns">
        <Button onClick={() => navigate("/add")}>Add Student</Button>
      </div>
      <DeleteModal show={modalShow} onHide={() => setModalShow(false)} />
    </div>
  );
};

export default Students;
