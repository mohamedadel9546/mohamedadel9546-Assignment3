# [Part F]
# Stack and Heap Memory Execution Walkthrough

## Step 1: `Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };`

```text
       STACK                               HEAP
+------------------+             +--------------------------+
|  Variable | Value|             | Address: 0x00A1          |
+------------------+             +--------------------------+
|  o1       |0x00A1| ----------->| OrderId: 1               |
+------------------+             | CustomerName: "Ali"      |
                                 | IsPaid: false            |
                                 | ... (Other fields)       |
                                 +--------------------------+
```
**Explanation:** 
A new `Order` object is instantiated in the Heap at address `0x00A1`, and the reference variable `o1` is created on the Stack holding this memory address.

---

## Step 2: `Order o2 = o1;`

```text
       STACK                               HEAP
+------------------+             +--------------------------+
|  Variable | Value|             | Address: 0x00A1          |
+------------------+             +--------------------------+
|  o1       |0x00A1| ----------->| OrderId: 1               |
|  o2       |0x00A1| -----------/| CustomerName: "Ali"      |
+------------------+             | IsPaid: false            |
                                 | ... (Other fields)       |
                                 +--------------------------+
```
**Explanation:** 
Assigning `o1` to `o2` copies the reference address (`0x00A1`) onto the Stack, so both variables now point to the exact same object instance on the Heap.

---

## Step 3: `o2.IsPaid = true;`

```text
       STACK                               HEAP
+------------------+             +--------------------------+
|  Variable | Value|             | Address: 0x00A1          |
+------------------+             +--------------------------+
|  o1       |0x00A1| ----------->| OrderId: 1               |
|  o2       |0x00A1| -----------/| CustomerName: "Ali"      |
+------------------+             | IsPaid: true  <--UPDATED!|
                                 | ... (Other fields)       |
                                 +--------------------------+
```
**Explanation:** 
Modifying `o2.IsPaid` updates the shared object on the Heap at address `0x00A1`, meaning reading `o1.IsPaid` will also reflect this change (`true`).

---

## What would be different with structs?

If `Order` were a `struct` (a Value Type like `Point`) instead of a `class`:
1. **No Heap Allocation:** The entire `Point` data would be stored directly inside the **Stack** variable itself, with no Heap addresses involved.
2. **Copy Value Semantics:** Executing `Point p2 = p1;` would make a complete, independent copy of all struct fields on the Stack. Modifying `p2.X` would only update `p2`'s Stack slot and would have zero effect on `p1`.