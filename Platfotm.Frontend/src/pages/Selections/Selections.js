import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getSelections,
  reset,
} from "../../features/selections/selectionsSlice";
import { useNavigate } from "react-router-dom";
import dayjs from "dayjs";

import "../../assets/styles/table.css";
import "../../pages/Students/styles/students.css";
import "react-pagination-bar/dist/index.css";
import { Button } from "react-bootstrap";

import Select from "react-select";
import { Pagination } from "react-pagination-bar";

const Selections = () => {
  const [filter, setFilter] = useState("");
  const [value, setValue] = useState("");
  const [sort, setSort] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  //const [modalShow, setModalShow] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { selections } = useSelector((state) => state.selections);

  useEffect(() => {
    const data = {
      api: `/api/selections?filter=${filter}&value=${value}&sort=${sort}&page=${page}&pageSize=${pageSize}`,
      token: user?.data?.token,
    };
    dispatch(getSelections(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token, sort, value, page]);

  const options = [
    { value: "program", label: "Program" },
    { value: "", label: "None" },
  ];

  const selectionStatus = {
    0: "Active",
    1: "Complete",
  };

  return (
    <div>
      <h1>Students</h1>
      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th>Status</th>
            <th>Program</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {selections?.data?.map((sel) => {
            return (
              <tr key={sel.id}>
                <td data-label="Title">{sel.title}</td>
                <td data-label="Start Date">
                  {dayjs(sel.startDate).format("DD/MM/YYYY")}
                </td>
                <td data-label="End Date">
                  {dayjs(sel.endDate).format("DD/MM/YYYY")}
                </td>
                <td data-label="Status">{selectionStatus[sel.status]}</td>
                <td data-label="Program">{sel.program?.title}</td>
                <td data-label="Actions">
                  <Button
                    variant="outline-success"
                    size="sm"
                    className="table-btn"
                    //onClick={() => navigate("/edit")}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="outline-danger"
                    size="sm"
                    className="table-btn"
                    //onClick={() => setModalShow(true)}
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
          totalItems={selections?.count}
          itemsPerPage={pageSize}
          onlyPageNumbers={true}
          onPageChange={(pageNumber) => setPage(pageNumber)}
        />
      </div>
      <div className="students-btns">
        <Button onClick={() => navigate("/add")}>
          Add Student to selection
        </Button>
        <Button onClick={() => navigate("/add")}>
          Remove Student from selection
        </Button>
        <Button onClick={() => navigate("/add")}>Add Selection</Button>
      </div>
      {/* <DeleteModal show={modalShow} onHide={() => setModalShow(false)} /> */}
    </div>
  );
};

export default Selections;
