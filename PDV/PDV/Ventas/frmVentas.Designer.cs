namespace PDV.Ventas
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClientes = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVentasDia = new System.Windows.Forms.Button();
            this.btnVentasDomicilio = new System.Windows.Forms.Button();
            this.btnVentasPendientes = new System.Windows.Forms.Button();
            this.btnVentaDomicilio = new System.Windows.Forms.Button();
            this.btnVentaPendiente = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtTotalVenta = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbcVentas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IEPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpVenta = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbcVentas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClientes);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1382, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Snow;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Image = global::PDV.Properties.Resources.buscar;
            this.btnClientes.Location = new System.Drawing.Point(301, 15);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(165, 32);
            this.btnClientes.TabIndex = 13;
            this.btnClientes.Text = "Cambiar Cliente";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnClientes, "Cambiar Cliente de Venta");
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(73, 17);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(222, 29);
            this.txtCliente.TabIndex = 12;
            this.txtCliente.Text = "Cliente Mostrador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Código / Nombre Producto:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Snow;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::PDV.Properties.Resources.agregar;
            this.btnAgregar.Location = new System.Drawing.Point(724, 48);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(165, 32);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar Producto";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnAgregar, "Agregar el Producto a la Venta");
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(628, 50);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(90, 29);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(547, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(214, 52);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(327, 29);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnVentasDia);
            this.panel1.Controls.Add(this.btnVentasDomicilio);
            this.panel1.Controls.Add(this.btnVentasPendientes);
            this.panel1.Controls.Add(this.btnVentaDomicilio);
            this.panel1.Controls.Add(this.btnVentaPendiente);
            this.panel1.Controls.Add(this.btnPagar);
            this.panel1.Controls.Add(this.txtTotalVenta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 575);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 58);
            this.panel1.TabIndex = 2;
            // 
            // btnVentasDia
            // 
            this.btnVentasDia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVentasDia.BackColor = System.Drawing.Color.Snow;
            this.btnVentasDia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasDia.Image = global::PDV.Properties.Resources.dia;
            this.btnVentasDia.Location = new System.Drawing.Point(7, 17);
            this.btnVentasDia.Name = "btnVentasDia";
            this.btnVentasDia.Size = new System.Drawing.Size(133, 32);
            this.btnVentasDia.TabIndex = 18;
            this.btnVentasDia.Text = "Ventas del Día";
            this.btnVentasDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentasDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnVentasDia, "Listado de Ventas del Dia");
            this.btnVentasDia.UseVisualStyleBackColor = false;
            // 
            // btnVentasDomicilio
            // 
            this.btnVentasDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVentasDomicilio.BackColor = System.Drawing.Color.Snow;
            this.btnVentasDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasDomicilio.Image = global::PDV.Properties.Resources.domicilios;
            this.btnVentasDomicilio.Location = new System.Drawing.Point(553, 19);
            this.btnVentasDomicilio.Name = "btnVentasDomicilio";
            this.btnVentasDomicilio.Size = new System.Drawing.Size(128, 32);
            this.btnVentasDomicilio.TabIndex = 17;
            this.btnVentasDomicilio.Text = "Ventas a Domicilio";
            this.btnVentasDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentasDomicilio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnVentasDomicilio, "Lista de Ventas a Domicilio");
            this.btnVentasDomicilio.UseVisualStyleBackColor = false;
            this.btnVentasDomicilio.Visible = false;
            // 
            // btnVentasPendientes
            // 
            this.btnVentasPendientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVentasPendientes.BackColor = System.Drawing.Color.Snow;
            this.btnVentasPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasPendientes.Image = global::PDV.Properties.Resources.pendietes;
            this.btnVentasPendientes.Location = new System.Drawing.Point(419, 19);
            this.btnVentasPendientes.Name = "btnVentasPendientes";
            this.btnVentasPendientes.Size = new System.Drawing.Size(128, 32);
            this.btnVentasPendientes.TabIndex = 16;
            this.btnVentasPendientes.Text = "Ventas Pendiente";
            this.btnVentasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentasPendientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnVentasPendientes, "Lista de Ventas Pendientes");
            this.btnVentasPendientes.UseVisualStyleBackColor = false;
            this.btnVentasPendientes.Visible = false;
            // 
            // btnVentaDomicilio
            // 
            this.btnVentaDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVentaDomicilio.BackColor = System.Drawing.Color.Snow;
            this.btnVentaDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentaDomicilio.Image = global::PDV.Properties.Resources.domicilio;
            this.btnVentaDomicilio.Location = new System.Drawing.Point(285, 19);
            this.btnVentaDomicilio.Name = "btnVentaDomicilio";
            this.btnVentaDomicilio.Size = new System.Drawing.Size(128, 32);
            this.btnVentaDomicilio.TabIndex = 15;
            this.btnVentaDomicilio.Text = "Venta Domicilio";
            this.btnVentaDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentaDomicilio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnVentaDomicilio, "Generar Venta a Domicilio");
            this.btnVentaDomicilio.UseVisualStyleBackColor = false;
            this.btnVentaDomicilio.Visible = false;
            // 
            // btnVentaPendiente
            // 
            this.btnVentaPendiente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVentaPendiente.BackColor = System.Drawing.Color.Snow;
            this.btnVentaPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentaPendiente.Image = global::PDV.Properties.Resources.archivar;
            this.btnVentaPendiente.Location = new System.Drawing.Point(682, 19);
            this.btnVentaPendiente.Name = "btnVentaPendiente";
            this.btnVentaPendiente.Size = new System.Drawing.Size(128, 32);
            this.btnVentaPendiente.TabIndex = 14;
            this.btnVentaPendiente.Text = "Venta Pendiente";
            this.btnVentaPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentaPendiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnVentaPendiente, "Generar Venta pendiente");
            this.btnVentaPendiente.UseVisualStyleBackColor = false;
            this.btnVentaPendiente.Visible = false;
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagar.BackColor = System.Drawing.Color.Snow;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = global::PDV.Properties.Resources.pagar;
            this.btnPagar.Location = new System.Drawing.Point(1191, 6);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(187, 45);
            this.btnPagar.TabIndex = 11;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.btnPagar, "Realizar el Pago de la Venta");
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalVenta.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVenta.Location = new System.Drawing.Point(981, 6);
            this.txtTotalVenta.Multiline = true;
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Size = new System.Drawing.Size(201, 45);
            this.txtTotalVenta.TabIndex = 11;
            this.txtTotalVenta.Text = "$ 0.00";
            this.txtTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalVenta.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.tbcVentas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1382, 482);
            this.panel2.TabIndex = 3;
            // 
            // tbcVentas
            // 
            this.tbcVentas.Controls.Add(this.tabPage1);
            this.tbcVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcVentas.Location = new System.Drawing.Point(0, 0);
            this.tbcVentas.Name = "tbcVentas";
            this.tbcVentas.SelectedIndex = 0;
            this.tbcVentas.Size = new System.Drawing.Size(1382, 482);
            this.tbcVentas.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCategorias);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1374, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Venta X";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.AllowUserToOrderColumns = true;
            this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategorias.ColumnHeadersHeight = 30;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Producto,
            this.Cantidad,
            this.Costo,
            this.PrecioVenta,
            this.IVA,
            this.IEPS,
            this.SubTotal,
            this.Impuestos,
            this.Total});
            this.dgvCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategorias.EnableHeadersVisualStyles = false;
            this.dgvCategorias.Location = new System.Drawing.Point(3, 3);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategorias.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCategorias.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(1368, 447);
            this.dgvCategorias.TabIndex = 1;
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 3.82481F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 100;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Producto
            // 
            this.Producto.FillWeight = 109.4715F;
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 480;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cantidad
            // 
            this.Cantidad.FillWeight = 123.803F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 100;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Costo
            // 
            this.Costo.FillWeight = 250.4346F;
            this.Costo.HeaderText = "Costo";
            this.Costo.MinimumWidth = 100;
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.FillWeight = 507.6141F;
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.MinimumWidth = 100;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            // 
            // IVA
            // 
            this.IVA.FillWeight = 0.9703687F;
            this.IVA.HeaderText = "IVA";
            this.IVA.MinimumWidth = 100;
            this.IVA.Name = "IVA";
            this.IVA.ReadOnly = true;
            // 
            // IEPS
            // 
            this.IEPS.FillWeight = 0.9703687F;
            this.IEPS.HeaderText = "IEPS";
            this.IEPS.MinimumWidth = 100;
            this.IEPS.Name = "IEPS";
            this.IEPS.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.FillWeight = 0.9703687F;
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.MinimumWidth = 100;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // Impuestos
            // 
            this.Impuestos.FillWeight = 0.9703687F;
            this.Impuestos.HeaderText = "Impuestos";
            this.Impuestos.MinimumWidth = 100;
            this.Impuestos.Name = "Impuestos";
            this.Impuestos.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.FillWeight = 0.9703687F;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 100;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::PDV.Properties.Resources.pendietes;
            this.button1.Location = new System.Drawing.Point(146, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 32);
            this.button1.TabIndex = 19;
            this.button1.Text = "Cotización";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpVenta.SetToolTip(this.button1, "Listado de Ventas del Dia");
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1382, 633);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbcVentas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbcVentas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtTotalVenta;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVentaPendiente;
        private System.Windows.Forms.Button btnVentaDomicilio;
        private System.Windows.Forms.Button btnVentasPendientes;
        private System.Windows.Forms.Button btnVentasDomicilio;
        private System.Windows.Forms.Button btnVentasDia;
        private System.Windows.Forms.ToolTip ttpVenta;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IEPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button button1;
    }
}