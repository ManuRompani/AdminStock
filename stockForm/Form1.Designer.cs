namespace stockForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStcok = new System.Windows.Forms.DataGridView();
            this.picboxStock = new System.Windows.Forms.PictureBox();
            this.cboxCampo = new System.Windows.Forms.ComboBox();
            this.cboxCriterio = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tboxFiltro = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.tboxAuxiliar = new System.Windows.Forms.TextBox();
            this.lblAuxiliar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStcok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStcok
            // 
            this.dgvStcok.AllowUserToAddRows = false;
            this.dgvStcok.AllowUserToDeleteRows = false;
            this.dgvStcok.AllowUserToResizeColumns = false;
            this.dgvStcok.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.NullValue = null;
            this.dgvStcok.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStcok.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStcok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStcok.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStcok.GridColor = System.Drawing.SystemColors.Control;
            this.dgvStcok.Location = new System.Drawing.Point(44, 107);
            this.dgvStcok.MultiSelect = false;
            this.dgvStcok.Name = "dgvStcok";
            this.dgvStcok.ReadOnly = true;
            this.dgvStcok.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStcok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStcok.Size = new System.Drawing.Size(443, 226);
            this.dgvStcok.TabIndex = 0;
            this.dgvStcok.SelectionChanged += new System.EventHandler(this.dgvStcok_SelectionChanged);
            // 
            // picboxStock
            // 
            this.picboxStock.Location = new System.Drawing.Point(498, 107);
            this.picboxStock.Name = "picboxStock";
            this.picboxStock.Size = new System.Drawing.Size(239, 226);
            this.picboxStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxStock.TabIndex = 1;
            this.picboxStock.TabStop = false;
            // 
            // cboxCampo
            // 
            this.cboxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCampo.FormattingEnabled = true;
            this.cboxCampo.Location = new System.Drawing.Point(105, 65);
            this.cboxCampo.Name = "cboxCampo";
            this.cboxCampo.Size = new System.Drawing.Size(121, 21);
            this.cboxCampo.TabIndex = 2;
            this.cboxCampo.SelectedIndexChanged += new System.EventHandler(this.cboxCampo_SelectedIndexChanged);
            // 
            // cboxCriterio
            // 
            this.cboxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCriterio.FormattingEnabled = true;
            this.cboxCriterio.Location = new System.Drawing.Point(232, 65);
            this.cboxCriterio.Name = "cboxCriterio";
            this.cboxCriterio.Size = new System.Drawing.Size(121, 21);
            this.cboxCriterio.TabIndex = 3;
            this.cboxCriterio.SelectedIndexChanged += new System.EventHandler(this.cboxCriterio_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(43, 68);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(56, 15);
            this.lblFiltro.TabIndex = 4;
            this.lblFiltro.Text = "Fitrar por";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(587, 63);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tboxFiltro
            // 
            this.tboxFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tboxFiltro.Location = new System.Drawing.Point(359, 65);
            this.tboxFiltro.Name = "tboxFiltro";
            this.tboxFiltro.Size = new System.Drawing.Size(108, 20);
            this.tboxFiltro.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(47, 349);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(156, 349);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(266, 349);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(92, 23);
            this.btnDetalle.TabIndex = 10;
            this.btnDetalle.Text = "Ver en detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // lblAyuda
            // 
            this.lblAyuda.AutoSize = true;
            this.lblAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyuda.Location = new System.Drawing.Point(361, 45);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(80, 13);
            this.lblAyuda.TabIndex = 13;
            this.lblAyuda.Text = "Label de ayuda";
            this.lblAyuda.Visible = false;
            // 
            // tboxAuxiliar
            // 
            this.tboxAuxiliar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxAuxiliar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tboxAuxiliar.Enabled = false;
            this.tboxAuxiliar.Location = new System.Drawing.Point(473, 65);
            this.tboxAuxiliar.Name = "tboxAuxiliar";
            this.tboxAuxiliar.Size = new System.Drawing.Size(108, 20);
            this.tboxAuxiliar.TabIndex = 14;
            // 
            // lblAuxiliar
            // 
            this.lblAuxiliar.AutoSize = true;
            this.lblAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuxiliar.Location = new System.Drawing.Point(470, 45);
            this.lblAuxiliar.Name = "lblAuxiliar";
            this.lblAuxiliar.Size = new System.Drawing.Size(80, 13);
            this.lblAuxiliar.TabIndex = 15;
            this.lblAuxiliar.Text = "Label de ayuda";
            this.lblAuxiliar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 423);
            this.Controls.Add(this.lblAuxiliar);
            this.Controls.Add(this.tboxAuxiliar);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.tboxFiltro);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cboxCriterio);
            this.Controls.Add(this.cboxCampo);
            this.Controls.Add(this.picboxStock);
            this.Controls.Add(this.dgvStcok);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStcok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStcok;
        private System.Windows.Forms.PictureBox picboxStock;
        private System.Windows.Forms.ComboBox cboxCampo;
        private System.Windows.Forms.ComboBox cboxCriterio;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox tboxFiltro;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.TextBox tboxAuxiliar;
        private System.Windows.Forms.Label lblAuxiliar;
    }
}

